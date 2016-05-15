using System.Collections.Generic;

namespace CouchPotato.Model.Movie
{
    public class Info
    {
        public Rating rating { get; set; }
        public List<string> genres { get; set; }
        public int tmdb_id { get; set; }
        public string plot { get; set; }
        public string tagline { get; set; }
        public string original_title { get; set; }
        public bool via_imdb { get; set; }
        public string mpaa { get; set; }
        public bool via_tmdb { get; set; }
        public List<string> directors { get; set; }
        public List<string> titles { get; set; }
        public string imdb { get; set; }
        public int year { get; set; }
        public Images images { get; set; }
        public List<string> actors { get; set; }
        public List<string> writers { get; set; }
        public int runtime { get; set; }
        public string type { get; set; }
        public string released { get; set; }
    }
}