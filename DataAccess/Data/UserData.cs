using DataAccess.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace DataAccess.Data
{
    public static class UserData
    {
        private static readonly HttpsClientHandlerService _handler = new HttpsClientHandlerService();
        private static readonly HttpClient _client = new HttpClient(_handler.GetPlatformMessageHandler());
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private static readonly string _restUrl = "http://10.0.2.2:8888";

        public static async Task<UserModel> GetUser(int id)
        {
            Uri uri = new Uri($"{_restUrl}/Users/{id}");
            UserModel data = new UserModel();
            try
            {
                HttpResponseMessage message = await _client.GetAsync(uri);
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    data = JsonSerializer.Deserialize<UserModel>(json, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return data;
        }

        public static async Task InsertUser(string name, string email, string password, string gender, byte[] photo, string interestedM, string interestedF, DateTime birthday)
        {
            Uri uri = new Uri($"{_restUrl}/Users");
            UserModel data = new UserModel { Name = name, Email = email, Password = password, Gender = gender, Photo = photo, InterestedM = interestedM, InterestedF = interestedF, Birthday = birthday };

            try
            {
                string json = JsonSerializer.Serialize(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public static async Task UpdateUser(int id, byte[] photo, string interestedF, string interestedM, string aboutMe, int minAgePreference, int maxAgePreference)
        {
            Uri uri = new Uri($"{_restUrl}/Users");
            UserModel data = new UserModel { Id= id, Photo = photo, InterestedM = interestedM, InterestedF = interestedF, AboutMe = aboutMe, MinAgePreference= minAgePreference, MaxAgePreference = maxAgePreference };

            try
            {
                string json = JsonSerializer.Serialize(data, _serializerOptions);
                StringContent content= new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public static async Task DeleteUser(int id)
        {
            Uri uri = new Uri($"{_restUrl}/Users/{id}");

            try 
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public static async Task<List<InterestModel>> GetUserInterests(int userID)
        {
            Uri uri = new Uri($"{_restUrl}/Users/{userID}/Interests");
            List<InterestModel> data = new List<InterestModel>();
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

        public static async Task InsertUserInterest(int userID, int interestID)
        {
            Uri uri = new Uri($"{_restUrl}/Users/{userID}/Interests");
            InterestModel data = new InterestModel { Id = interestID };

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

        public static async Task DeleteUserInterests(int userID)
        {
            Uri uri = new Uri(string.Format(_restUrl, $"/Users/{userID}/Interests"));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
