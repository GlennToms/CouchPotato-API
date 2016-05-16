using System;


namespace CouchPotato.Sample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Create a client.
            const string apiKey = "123456789abcdefghijk";
            const string url = "http://127.0.0.1:8083"; //Replace by your CouchPotato location Hostname or IP
            var client = new Client(url, apiKey);

            var result = client.CouchPotato.IsAvaliable();
            
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
