using System.Net.Http.Json;

namespace Logger.Clients
{
    public class TelegramLogger : ITelegramLogger
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _groupId;

        public TelegramLogger(string botToken, string groupId)
        {
            _botToken = botToken;
            _groupId = groupId;
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Sends message to telegram
        /// </summary>
        /// <param name="message"></param>
        public async Task Log(string message)
        {
            // This is to trim top 2000. As there is limit on discord.
            if (message.Length > 1999)
            {
                message = message.Substring(0, 1998);
            }

            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";
            var data = new { chat_id = _groupId, text = message };
            await _httpClient.PostAsJsonAsync(url, data);
        }
    }
}