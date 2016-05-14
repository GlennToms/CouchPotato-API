using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Request
{
    internal class ApiRequest
    {
        public string Url { get; set; }

        public string Method { get; set; }

        public string ContentType { get; set; }

        public ApiRequest()
        {
            Method = "GET";
            ContentType = "application/json";
        }
    }
}
