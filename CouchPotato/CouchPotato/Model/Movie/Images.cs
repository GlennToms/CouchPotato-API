using System.Collections.Generic;

namespace CouchPotato.Model.Movie
{
    public class Images
    {
        public List<object> disc_art { get; set; }
        public List<string> poster { get; set; }
        public List<object> extra_thumbs { get; set; }
        public List<string> poster_original { get; set; }
        public List<object> landscape { get; set; }
        public List<string> backdrop_original { get; set; }
        public List<object> clear_art { get; set; }
        public List<object> logo { get; set; }
        public List<object> banner { get; set; }
        public List<string> backdrop { get; set; }
        public List<object> extra_fanart { get; set; }
    }
}