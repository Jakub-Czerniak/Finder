using DataAccess.Models;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace DataAccess
{
    public class Data
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _restUrl;

        public Data()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<bool> EmailIsUnique(string email)
        {
            Uri uri = new Uri(string.Format(_restUrl, "/Emails"));
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

        public async Task<List<InterestModel>> GetInterests()
        {
            List<InterestModel> data = new List<InterestModel>();

            Uri uri = new Uri(string.Format(_restUrl, "/Interest"));
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

        public async Task InsertUser(string name, string email, string password, string gender, byte[] photo, string interestedM, string interestedF, DateTime birthday)
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

        public async Task InsertUserInterest(int userID, int interestID)
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
    }
}
