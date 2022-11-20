using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Data
{
    public static class InterestsData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task<List<InterestModel>> GetInterests()
        {
            List<InterestModel> data = new List<InterestModel>();

            Uri uri = new Uri($"{_restUrl}/Interests");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    data = JsonSerializer.Deserialize<List<InterestModel>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
            }

            return data;
        }
    }
}
