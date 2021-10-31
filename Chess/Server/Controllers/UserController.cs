using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Chess.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Chess.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

namespace Chess.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ChessDbContext _context;

        public UserController(ILogger<UserController> logger, ChessDbContext context)
        {
            _logger = logger;
            _context = context;
        }

     
        //Authentication Methods
        [HttpPost("loginuser")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            // user.Password = Utility.Encrypt(user.Password);
            var loggedInUser = await _context.Users
                .Where(u => u.EmailAddress == user.EmailAddress && u.Password == user.Password).FirstOrDefaultAsync();

            if (loggedInUser != null)
            {
                //create a claim
                var claimEmail = new Claim(ClaimTypes.Email, loggedInUser.EmailAddress);
                // var firstName = new Claim(ClaimTypes.Name, loggedInUser.FirstName);
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserId.ToString());
                
                var claimsIdentity = new ClaimsIdentity(new[] {claimEmail,claimNameIdentifier}, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                
                //Sign In User
                await HttpContext.SignInAsync(claimsPrincipal, GetAuthenticationProperties());
            }

            return await Task.FromResult(loggedInUser);
        }

        [HttpGet("getcurrentuser")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var currentUser = new User();

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                currentUser.EmailAddress = userEmail;
                currentUser = await _context.Users.Where(u => u.EmailAddress == userEmail)
                    .FirstOrDefaultAsync();
                
                if (currentUser == null)
                {
                    currentUser = new User {UserId = _context.Users.Max(u => u.UserId) + 1, EmailAddress = userEmail};
                    currentUser.Password = Utility.Encrypt(currentUser.EmailAddress);
                    currentUser.Source = "EXTL";
                    _context.Users.Add(currentUser);
                    await _context.SaveChangesAsync();
                }
                
            }

            return await Task.FromResult(currentUser);
        }

        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }

        [HttpGet("googleSignIn")]
        public async Task GoogleSignIn()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                GetAuthenticationProperties());
        }


        [HttpGet("notauthorized")]
        public IActionResult NotAuthorized()
        {
            return Unauthorized();
        }


        public AuthenticationProperties GetAuthenticationProperties()
        {
            return  new AuthenticationProperties()
            {
                IsPersistent = true,
                // ExpiresUtc = DateTimeOffset.Now.AddMinutes(1),
                RedirectUri = "/profile"
            };
        }



    }
}

//todo same user should not allow himself as opponent 