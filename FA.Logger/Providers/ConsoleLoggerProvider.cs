using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class ConsoleLoggerProvider : IMyLoggerProvider
    {
        public async Task Log(string message, LogLevel logLevel = LogLevel.Information)
        {
            Console.WriteLine(message);
        }
    }
}
