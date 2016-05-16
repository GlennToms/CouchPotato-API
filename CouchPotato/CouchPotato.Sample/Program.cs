﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model.Movie;
using Type = CouchPotato.Model.Logging.Type;

namespace CouchPotato.Sample
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //Create a client.
            const string apiKey = "8fbfe59b9aee44c1ac42524ca8953be1";
            const string url = "http://Server01:6886"; //Replace by your CouchPotato location Hostname or IP
            var client = new Client(url, apiKey);

            var result = client.CouchPotato.IsAvaliable();

            Console.WriteLine();
            //Console.WriteLine(result.Total);
            Console.ReadLine();
        }
    }
}
