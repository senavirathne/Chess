using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ChessDbContext _context;

        public ContactsController(ILogger<UserController> logger, ChessDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getcontacts")]
        public async Task<List<User>> GetContacts()
        {
            return await _context.Users.ToListAsync(); // why it is used as not awaitable in tutorial
        }

        [HttpGet("getallcontacts")]
        public List<User> GetAllContacts()
        {
            List<User> users = new();
            users.AddRange(Enumerable.Range(0, 2001)
                .Select(x => new User {UserId = x, FirstName = $"first{x}", LastName = $"last{x}"}));
            return users;
        }

        [HttpGet("getonlyvisiblecontacts")]
        public List<User> GetOnlyVisibleContacts(int startIndex, int count)
        {
            List<User> users = new();
            users.AddRange(Enumerable.Range(startIndex, count)
                .Select(x => new User {UserId = x, FirstName = $"First{x}", LastName = $"Last{x}"}));

            return users;
        }

        [HttpGet("getcontactscount")]
        public async Task<int> GetContactsCount()
        {
            // throw new IndexOutOfRangeException();
            return await _context.Users.CountAsync();
        }

        [HttpGet("getvisiblecontacts")]
        public async Task<List<User>> GetVisibleContacts(int startIndex, int count)
        {
            return await _context.Users.Skip(startIndex).Take(count).ToListAsync();
        }

    }
}
