using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a client.
            string apiKey = "8fbfe59b9aee44c1ac42524ca8953be1";
            string url = "http://Server01:6886"; //Replace by your sickrage location
            var client = new Client(url, apiKey);

            //var IsAvaliable = client.Api.IsAvaliable();
            //Console.WriteLine(IsAvaliable.ToString());

            //var Version = client.Api.GetVersion();
            //Console.WriteLine(Version);

            //client.CouchPotato

            Console.ReadLine();
        }
    }
}
