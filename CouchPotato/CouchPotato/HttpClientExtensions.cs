using CouchPotato.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato
{
    public static class HttpClientExtensions
    {
        // Returns Dynamic opjects (strings)
        public static string GetStringNoJson(this HttpClient client, string command)
        {
            var task = GetStringNoJsonAsync(client, command);

            task.Wait();

            return task.Result;
        }

        // Returns Dynamic opjects (strings)
        public static async Task<string> GetStringNoJsonAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return jsonString;
        }


        // Returns Dynamic opjects Json Parsed
        public static dynamic GetDynamic(this HttpClient client, string command)
        {
            var task = client.GetDynamicAsync(command);

            task.Wait();

            return task.Result;
        }

        // Returns Dynamic opjects Json Parsed
        public static async Task<dynamic> GetDynamicAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JObject.Parse(jsonString);
        }


        // Generic returns Json filled classes
        public static T GetJson<T>(this HttpClient client, string command)
        {
            var task = client.GetJsonAsync<T>(command);

            task.Wait();

            return task.Result;
        }

        // Generic returns Json filled classes
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<T>(jsonString);
        }


        // Get Bytes
        public static byte[] GetImage(this HttpClient client, string command)
        {
            var task = client.GetImageAsync(command);
            task.Wait();

            return task.Result;
        }

        // Get Bytes
        public static async Task<byte[]> GetImageAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            byte[] img = await response.Content.ReadAsByteArrayAsync();

            return img;
        }


        //Util to adjust returned Headers data.
        private static void AdjustContentType(HttpResponseMessage response)
        {
            response.Content.Headers.ContentType.CharSet = "UTF-8";
        }
    }
}
