using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class DiscordLoggerProvider : IMyLoggerProvider
    {
        private readonly HttpClient _httpClient;

        public DiscordLoggerProvider(string webhookUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(webhookUrl) };
        }

        public DiscordLoggerProvider(string webhookUrl, HttpClient? httpClient)
        {
            _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri(webhookUrl) };
        }

        /// <summary>
        /// Creates log and sends to discord
        /// </summary>
        /// <param name="message"></param>
        private async Task Log(string message)
        {
            // This is to trim top 2000. As there is limit on discord.
            if (message.Length > 1999)
            {
                message = message.Substring(0, 1998);
            }

            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("content", message) });
            var responseMessage = await _httpClient.PostAsync("", content);
            responseMessage.EnsureSuccessStatusCode();
        }

        public async Task Log(string message, LogLevel logLevel)
        {
            if (logLevel >= LogLevel.Error)
            {
                await Log(message);
            }
        }
    }
}
