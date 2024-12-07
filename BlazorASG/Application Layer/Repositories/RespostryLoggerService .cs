using BlazorASG.Application_Layer.Interfaces;

namespace BlazorASG.Application_Layer.Repositories
{
    
        public class ConsoleLoggerService : ILoggerService
        {
        private readonly List<string> _logs = new();

        public void Logg(string message, string level = "Info")
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            _logs.Add(logEntry);
        }

        public List<string> GetLogs()
        {
            return _logs;
        }

    }
}
