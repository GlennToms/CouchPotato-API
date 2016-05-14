using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Model
{
    public class Response
    {
        public string Message { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseResult Result { get; set; }
    }
}
