using VigilanceClearance.Application.Interfaces;
using VigilanceClearance.Domain.Model;
using VigilanceClearance.Infrastructure.Infrastructure.Persistence.DbContexts;

namespace VigilanceClearance.Application.Services
{
    public class LogService:ILogService
    {
        private readonly VCDbContext _context;

        public LogService(VCDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(string message, string stackTrace = "", string level = "Error")
        {
            var log = new LogEntry
            {
                Message = message,
                StackTrace = stackTrace,
                Level = level,
                CreatedAt = DateTime.UtcNow
            };

            _context.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
