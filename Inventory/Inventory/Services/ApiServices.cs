using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Inventory.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inventory.Services
{
    class ApiServices
    {
        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Constants.BaseApiAddress + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);


            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Response = " + content);
            JObject jsonObject = JsonConvert.DeserializeObject<dynamic>(content);
            if(jsonObject.ContainsKey("error"))
            {
                return jsonObject.Value<string>("error_description");
            }
            var accessToken = jsonObject.Value<string>("access_token");

            return accessToken;
        }

        public async Task<List<ScanModels>> GetScansAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(Constants.BaseApiAddress + "/api/Scans");

            List<ScanModels> scans = JsonConvert.DeserializeObject<List<ScanModels>>(content);
            
            return scans;
        }
        public async Task<string> PostScanAsync(ScanModels scan, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(scan);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "/api/Scans", content);

            Debug.WriteLine("Response from POST = " + response.StatusCode);

            return response.StatusCode.ToString();
            
           
        }

        public async Task PutScanAsync(ScanModels scan, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(scan);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(Constants.BaseApiAddress + "/api/Scans/" + scan.Id, content);
            if(response.IsSuccessStatusCode)
            {
                Debug.WriteLine(response);
            }
        }

        public async Task DeleteScanAsync(int id, string accesToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesToken);

            var response = await client.DeleteAsync(Constants.BaseApiAddress + "/api/Scans/" + id);
        }

        public async Task<List<ScanModels>> SearchScansAsync(string accessToken,string keyword)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string content = await client.GetStringAsync(Constants.BaseApiAddress + "/api/SearchScans/" + keyword);

            List<ScanModels> scans = JsonConvert.DeserializeObject<List<ScanModels>>(content);

            return scans;
        }
    }
}
