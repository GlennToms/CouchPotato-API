using System.Collections.Generic;
using Newtonsoft.Json;

namespace CouchPotato.Model.Movie
{
    public class MovieList : StatusCodes
    {
        [JsonProperty("Movies")]
        public List<Movie> Movies { get; set; }
    }
}