using System.Net.Http.Json;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class TelegramNotifyProvider : INotifyProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _botToken;
        private readonly string _groupId;

        public TelegramNotifyProvider(string botToken, string groupId)
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
            var responseMessage = await _httpClient.PostAsJsonAsync(url, data);
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
