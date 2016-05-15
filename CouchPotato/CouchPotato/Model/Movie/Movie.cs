using System.Collections.Generic;
using Newtonsoft.Json;

namespace CouchPotato.Model.Movie
{
    public class Movie : StatusCodes
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }

        [JsonProperty("_t")]
        public string Type1 { get; set; }

        [JsonProperty("releases")]
        public List<Release> Releases { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("_rev")]
        public string Revision { get; set; }

        [JsonProperty("profile_id")]
        public object ProfileId { get; set; }

        [JsonProperty("_id")]
        public string ID { get; set; }

        [JsonProperty("category_id")]
        public object CategoryId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("files")]
        public ImagePoster Files { get; set; }

        [JsonProperty("identifiers")]
        public Identifiers Identifiers { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}