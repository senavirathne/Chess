using System;
using System.Threading.Tasks;
using Chess.Server.Models;
using Chess.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chess.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class SettingsController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly ChessDbContext _context;

        public SettingsController(ILogger<UserController> logger, ChessDbContext context)
        {
            this.logger = logger;
            this._context = context;
        }

        [HttpGet("updatetheme/")]
        public async Task<User> UpdateTheme(string userId, string value)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == Convert.ToInt32(userId));
            user.DarkTheme = value.ToLower() == "true";

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpGet("updatenotifications")]
        public async Task<User> UpdateNotifications(string userId, string value)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == Convert.ToInt32(userId));
            user.Notifications = value.ToLower() == "true";
            return await Task.FromResult(user);
        }
    }
}
