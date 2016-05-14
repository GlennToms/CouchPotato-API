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

        public static async Task<dynamic> GetDynamicAsync(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JObject.Parse(jsonString);
        }

        public static async Task<T> GetAsync<T>(this HttpClient client, string command)
        {
            var response = await client.GetResponseAsync<T>(command);
            return response.Data;
        }

        public static T Get<T>(this HttpClient client, string command)
        {
            var task = client.GetAsync<T>(command);
            task.Wait();

            return task.Result;
        }

        public static T Get<T>(this HttpClient client, string command, params object[] parameters)
        {
            var task = client.GetAsync<T>(string.Format(command, parameters));
            task.Wait();

            return task.Result;
        }

        public static async Task<DataResponse<T>> GetResponseAsync<T>(this HttpClient client, string command)
        {
            var response = await client.GetAsync(Settings.Instance.Url + command);
            AdjustContentType(response);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DataResponse<T>>(jsonString);
        }

        public static DataResponse<T> GetResponse<T>(this HttpClient client, string command)
        {
            var task = client.GetResponseAsync<T>(command);
            task.Wait();

            return task.Result;
        }

        public static DataResponse<T> GetResponse<T>(this HttpClient client, string command, params object[] parameters)
        {
            var task = client.GetResponseAsync<T>(string.Format(command, parameters));
            task.Wait();

            return task.Result;
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
