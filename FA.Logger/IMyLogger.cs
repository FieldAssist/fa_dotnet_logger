namespace FA.Logger;

public interface IMyLogger
{
    public Task Log(Exception ex, string data = "", string? stackTrace = "", string? subtitle = null);
}
