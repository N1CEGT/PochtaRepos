﻿using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PochtaRossiiDesign1._0
{
    public class HttpRequest
    {

        public static async Task<T> GetAsync<T>(string address)
        {
            var clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (ao, f, s, a) => true };
            var client = new HttpClient(clientHandler);
            var response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        public static async Task<T> DeleteAsync<T>(string address)
        {
            var clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (ao, f, s, a) => true };
            var client = new HttpClient(clientHandler);
            var response = await client.DeleteAsync(address);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
        public static async Task PostAsync<T>(string address, object content)
        {
            var clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (ao, f, s, a) => true };
            var client = new HttpClient(clientHandler);
            var json = JsonConvert.SerializeObject(content);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(address, contents);
            response.EnsureSuccessStatusCode();
            
        }
        public static async Task<T> PutAsync<T>(string address, object content)
        {
            try
            {
                var clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (ao, f, s, a) => true };
                var client = new HttpClient(clientHandler);
                var json = JsonConvert.SerializeObject(content);
                var contents = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(address, contents);
                var responseContent = await response.Content.ReadAsStringAsync();
                var isSuccess = JsonConvert.DeserializeObject<T>(responseContent);
                return isSuccess;
            }
            catch (System.Exception)
            {
                return default;
            }
        }
    }
}
