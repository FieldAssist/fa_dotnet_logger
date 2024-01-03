namespace FA.Logger;

public interface IMyNotifier
{
    public Task Notify(string message);
}
