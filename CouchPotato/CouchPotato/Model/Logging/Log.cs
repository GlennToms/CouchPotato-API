using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model.Movie;
using Newtonsoft.Json;

namespace CouchPotato.Model.Logging
{
    public class Log : StatusCodes
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}