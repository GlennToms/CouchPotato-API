using System.Collections.Generic;
using Newtonsoft.Json;

namespace CouchPotato.Model.Movie
{
    public class ImagePoster
    {
        [JsonProperty("image_poster")]
        public List<string> Image_Poster { get; set; }
    }
}