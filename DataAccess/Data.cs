using DataAccess.Models;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using DataAccess;
using System.Reflection;
using System.Xml.Linq;

namespace DataAccess
{
    public static class Data
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

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return false;
        }

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

        public static async Task<UserModel> Login(string email, string password)
        {
            UserModel user = new UserModel();
            Uri uri = new Uri(string.Format(_restUrl, "/Users"));
            LoginModel data = new LoginModel { Email = email, Password = password};
            try
            {
                string json = JsonSerializer.Serialize<LoginModel>(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string contentReturned = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<UserModel>(contentReturned, _serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return user;
        }

        public static async Task InsertUser(string name, string email, string password, string gender, byte[] photo, string interestedM, string interestedF, DateTime birthday)
        {
            Uri uri = new Uri(string.Format(_restUrl, "/Users"));
            UserModel data = new UserModel { Name = name, Email = email, Password = password, Gender = gender, Photo = photo, InterestedM = interestedM, InterestedF = interestedF, Birthday = birthday };

            try
            {
                string json = JsonSerializer.Serialize<UserModel>(data, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PutAsync(uri, content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public static async Task InsertUserInterest(int userID, int interestID)
        {
            Uri uri = new Uri(string.Format(_restUrl, $"/Users/{userID}/Interests"));
            InterestModel data = new InterestModel { Id = interestID };

            try
            {
                string json = JsonSerializer.Serialize<InterestModel>(data, _serializerOptions);
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
