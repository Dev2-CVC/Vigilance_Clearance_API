using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigilanceClearance.Domain.Model
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; } = string.Empty;
        public string Level { get; set; } = "Error"; // or "Info", etc.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
