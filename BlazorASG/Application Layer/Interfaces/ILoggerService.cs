namespace BlazorASG.Application_Layer.Interfaces
{
    public interface ILoggerService
    {
        void Logg(string message, string level = "Info");
         List<string> GetLogs();
    }
}
