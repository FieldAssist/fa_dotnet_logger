namespace FA.Logger;

public interface IMyLogger
{
    Task LogInfo(string data = "");
    Task LogException(Exception ex, string data = "", string? stackTrace = null, string? subtitle = null);
    Task LogNotification(string data = "");
}
