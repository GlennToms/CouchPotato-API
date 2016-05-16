using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CouchPotato.Model.CouchPotato
{
    public class ApiModel : StatusCodes
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
