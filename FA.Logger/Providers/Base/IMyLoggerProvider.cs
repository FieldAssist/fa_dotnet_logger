using FA.Logger.Enum;

namespace FA.Logger.Providers.Base
{
    public interface IMyLoggerProvider
    {
        /// <summary>
        /// Logs to discord
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        Task Log(string message, LogLevel logLevel = LogLevel.Information);
    }
}
