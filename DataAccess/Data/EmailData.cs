using DataAccess.Models;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace DataAccess.Data
{
    public static class EmailData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task<bool> EmailIsUnique(string email)
        {
            Uri uri = new Uri($"{_restUrl}/Emails");
            EmailModel data = new EmailModel { Email = email };
            try
            {
                string json = JsonSerializer.Serialize<EmailModel>(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return false;
        }
    }
}
