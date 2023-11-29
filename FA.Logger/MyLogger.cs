using FA.Logger.Clients;

namespace FA.Logger
{
    public class MyLogger : IMyLogger
    {
        private readonly IMyLoggerProvider _myLoggerProvider;

        public MyLogger(IMyLoggerProvider myLoggerProvider)
        {
            _myLoggerProvider = myLoggerProvider;
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
        public async Task Log(Exception ex, string data = "", string? stackTrace = "", string? subtitle = null)
        {
            try
            {
                await LogToDiscord(ex, data, stackTrace ?? "", subtitle);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        private async Task LogToDiscord(Exception ex, string data, string? stackTrace, string? subtitle)
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

            await _myLoggerProvider.SaveLog(finalMsg);
        }
    }
}
