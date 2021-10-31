using Chess.Server.Models;
using Microsoft.Extensions.Logging;

namespace Chess.Server.Logging
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly ChessDbContext _context;

        public ApplicationLoggerProvider(ChessDbContext context)
        {
            _context = context;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_context);
        }

        public void Dispose()
        {
            
        }
    }
}