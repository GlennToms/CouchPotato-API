using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Model.Movie
{
    public class MovieSingle : StatusCodes
    {
        [JsonProperty("Movie")]
        public Movie Movie { get; set; }
    }
}
