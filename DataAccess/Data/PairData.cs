using System.Diagnostics;
using System.Text;
using System.Text.Json;
using DataAccess.Models;

namespace DataAccess.Data
{
    public static class PairData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task InsertDecision(int user1Id, int user2Id, string user1Decision)
        {
            Uri uri = new Uri($"{_restUrl}/Pairs");
            PairModel data = new PairModel{ User1Id = user1Id, User2Id = user2Id, User1Decision = user1Decision };
            try
            {
                string json = JsonSerializer.Serialize(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
            }
            catch (Exception ex) 
            { 
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public static async Task<List<UserModel>> GetPairs(int id)
        {
            Uri uri = new Uri($"{_restUrl}/Pairs/{id}");
            List<UserModel> data = new List<UserModel>();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonSerializer.Deserialize<List<UserModel>>(content, _serializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return data;
        }
    }
}
