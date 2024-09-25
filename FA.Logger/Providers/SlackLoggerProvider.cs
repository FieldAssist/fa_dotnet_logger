using System.Text;
using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class SlackLoggerProvider : IMyLoggerProvider
    {
        private readonly string _webhookUrl;

        public SlackLoggerProvider(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public async Task _Log(string message)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var payload = new
                    {
                        text = message
                    };

                    var jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(_webhookUrl, content);
                    response.EnsureSuccessStatusCode();

                    // Log or handle the response if needed
                    var responseString = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Console.Error.WriteLine($"Error sending notification: {ex.Message}");
                }
            }
        }

        public async Task Log(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Notify)
            {
                await _Log(message);
            }
        }
    }
}
