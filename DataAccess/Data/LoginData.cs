using DataAccess.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace DataAccess.Data
{
    public static class LoginData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task<UserModel> Login(string email, string password)
        {
            UserModel user = new UserModel();
            Uri uri = new Uri($"{_restUrl}/Login");
            LoginModel data = new LoginModel { Email = email, Password = password };
            try
            {
                string json = JsonSerializer.Serialize<LoginModel>(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string contentReturned = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<UserModel>(contentReturned, _serializerOptions);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);   
            }
            return null;
        }
    }
}
