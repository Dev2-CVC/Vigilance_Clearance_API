namespace VigilanceClearance.Application.Interfaces
{
    public interface ILogService
    {
        Task LogAsync(string message, string stackTrace = "", string level = "Error");
    }
}
