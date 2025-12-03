using System.Text;
using FA.Logger.Enum;
using FA.Logger.Providers.Base;

namespace FA.Logger.Providers
{
    public class SlackLoggerProvider : IMyLoggerProvider
    {
        private readonly string _webhookUrl;
#pragma warning disable IDISP006 // Implement IDisposable - The Log provider is used as singleton, so it is fine.
        private readonly HttpClient _httpClient;
#pragma warning restore IDISP006 // Implement IDisposable

        public SlackLoggerProvider(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
            _httpClient = new HttpClient();
        }

        public async Task _Log(string message)
        {
            try
            {
                var payload = new
                {
                    text = message
                };

                var jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);
                using var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                using var response = await _httpClient.PostAsync(_webhookUrl, content);
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

        public async Task Log(string message, LogLevel logLevel)
        {
            if (logLevel >= LogLevel.Error)
            {
                await _Log(message);
            }
        }
    }
}
