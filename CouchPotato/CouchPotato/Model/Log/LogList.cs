using System.Collections.Generic;
using Newtonsoft.Json;

namespace CouchPotato.Model.Logging
{
    public class LogList : StatusCodes
    {
        [JsonProperty("log")]
        public List<Log> Log { get; set; }
    }
}