using System.Collections.Generic;

namespace CouchPotato.Model.Movie
{
    public class Files
    {
        public List<string> nfo { get; set; }
        public List<string> movie { get; set; }
        public List<string> leftover { get; set; }
    }
}