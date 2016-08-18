using System;


namespace CouchPotato.Sample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Create a client.
            const string apiKey = "8fbfe59b9aee44c1ac42524ca8953be1"; //Replace by your CouchPotato API Key.
            const string url = "http://server01:6886"; //Replace by your CouchPotato location Hostname or IP.
            var client = new Client(url, apiKey);

            var result = client.Movie.GetMovies();
            
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }
}
