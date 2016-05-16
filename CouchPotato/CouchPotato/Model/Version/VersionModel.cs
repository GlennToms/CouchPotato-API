using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CouchPotato.Model
{
    public class VersionModel
    {
        public string OS { get; set; }

        public string Type { get; set; }

        public string Commit { get; set; }

        public string Release { get; set; }

        [JsonProperty("version")]
        public string VersionString { get; set; }

        public override string ToString()
        {
            return Commit;
        }
    }
}
