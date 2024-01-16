using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger
{
    public class MyLogger : IMyLogger
    {
        private readonly IEnumerable<IMyLoggerProvider> _myLoggerProvider;

        public MyLogger(IEnumerable<IMyLoggerProvider> myLoggerProvider)
        {
            _myLoggerProvider = myLoggerProvider;
        }

        private async Task Log(string data = "", LogLevel logLevel = LogLevel.Information)
        {
            foreach (var logger in _myLoggerProvider)
            {
                await logger.Log(data, logLevel);
            }
        }

        /// <summary>
        /// Logs information level messages with optional data.
        /// </summary>
        /// <param name="data"></param>
        public async Task LogInfo(string data = "")
        {
            await Log(data, LogLevel.Information);
        }

        /// <summary>
        /// Creates log and sends to discord, slack.
        /// Wrapped in try catch so as to prevent original process
        /// to break if error occurs while posting logs.
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="data">The string representing payload data</param>
        /// <param name="stackTrace"></param>
        /// <param name="subtitle">An optional subtitle to be logged</param>
        public async Task LogException(Exception ex,
            string data = "", string? stackTrace = "", string? subtitle = null)
        {
            try
            {
                await _LogError(ex, data, stackTrace ?? "", subtitle);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        private async Task _LogError(Exception ex, string data, string? stackTrace, string? subtitle)
        {
            var msg = ex.GetBaseException().Message;

            var finalMsg = "🐞Error🐞\n";
            finalMsg = $"{finalMsg}{msg}\n";

            if (data != "")
            {
                if (subtitle != null)
                {
                    finalMsg = $"{finalMsg}{subtitle}\n";
                }

                finalMsg = $"{finalMsg}\n----Payload START----\n";
                finalMsg = $"{finalMsg}{data}\n";
                finalMsg = $"{finalMsg}----Payload END----\n";
            }

            if (stackTrace != "")
            {
                finalMsg = $"{finalMsg}\n----StackTrace START----\n";
                finalMsg = $"{finalMsg}{stackTrace}\n";
                finalMsg = $"{finalMsg}----StackTrace END----\n";
            }

            await Log(finalMsg, LogLevel.Error);
        }

        public async Task LogNotification(string data = "")
        {
            await Log(data, LogLevel.Notify);
        }
    }
}
