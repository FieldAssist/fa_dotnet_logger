using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class ConsoleLoggerProvider : IMyLoggerProvider
    {
        public Task Log(string message, LogLevel logLevel)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
