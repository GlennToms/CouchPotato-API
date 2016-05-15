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
        public static dynamic GetDynamic(this HttpClient client, string command)
        {
            var task = client.GetDynamicAsync(command);

            task.Wait();

            return task.Result;
        }

        public static dynamic GetDynamicNoJSON(this HttpClient client, string command)
        {
            var task = client.GetDynamicNoJSONAsync(command);

            task.Wait();

            return task.Result;
        }

        public static async Task<dynamic> GetDynamicNoJSONAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return jsonString;
        }

        //My First
        public static T GetJson<T>(this HttpClient client, string command)
        {
            var task = client.GetJsonAsync<T>(command);

            task.Wait();

            return task.Result;
        }
        
        //My Second
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<T>(jsonString);

            return a;
            //return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<dynamic> GetDynamicAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JObject.Parse(jsonString);
        }
        

        public static async Task<byte[]> GetImageAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            byte[] img = await response.Content.ReadAsByteArrayAsync();

            return img;
        }

        public static byte[] GetImage(this HttpClient client, string command)
        {
            var task = client.GetImageAsync(command);
            task.Wait();

            return task.Result;
        }

        private static void AdjustContentType(HttpResponseMessage response)
        {
            response.Content.Headers.ContentType.CharSet = "UTF-8";
        }
    }
}
