using System;
using Chess.Server.Models;
using Chess.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Chess.Server.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly ChessDbContext _context;

        public DatabaseLogger(ChessDbContext context)
        {
            _context = context;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Log log = new();
            log.LogLevel = logLevel.ToString();
            log.EventName = eventId.Name;
            log.ExceptionMessage = exception?.Message;
            log.StackTrace = exception?.StackTrace;
            log.Source = "Server";
            log.CreatedDate = DateTime.Now.ToString();

            _context.Logs.AddAsync(log);//I added async
            _context.SaveChangesAsync();//I added async
        }
    }
}