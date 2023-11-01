namespace FA.Logger.Clients
{
    public class DiscordLogger : IDiscordLogger
    {
        private readonly HttpClient _httpClient;

        public DiscordLogger(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Creates log and sends to discord
        /// </summary>
        /// <param name="message"></param>
        public async Task Log(string message)
        {
            // This is to trim top 2000. As there is limit on discord.
            if (message.Length > 1999)
            {
                message = message.Substring(0, 1998);
            }

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("content", message)
            });
            await _httpClient.PostAsync("", content);
        }

        public async Task SaveLog(string message)
        {
            // This is to trim top 2000. As there is limit on discord.
            if (message.Length >= 2000)
            {
                message = message.Substring(0, 2000);
            }

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("content", message)
            });
            await _httpClient.PostAsync("", content);
        }
    }
}
