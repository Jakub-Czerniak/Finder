using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public static class MatchEngineData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task<MatchEngineModel> GetBestMatch(int userId)
        {
            Uri uri = new Uri($"{_restUrl}/MatchEngine");
            MatchEngineModel data = new MatchEngineModel { UserID = userId };
            MatchEngineModel dataReturned = new MatchEngineModel();
            try 
            {
                string json = JsonSerializer.Serialize(data, _serializerOptions);
                StringContent content = new StringContent(json,Encoding.UTF8,"application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
                if(response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dataReturned = JsonSerializer.Deserialize<MatchEngineModel>(responseContent,_serializerOptions);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return dataReturned;
        }

    }
}
