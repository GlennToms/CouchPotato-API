namespace CouchPotato.Model.Movie
{
    public class Release
    {
        public string status { get; set; }
        public Files files { get; set; }
        public string _id { get; set; }
        public string media_id { get; set; }
        public string _rev { get; set; }
        public string _t { get; set; }
        public bool is_3d { get; set; }
        public int last_edit { get; set; }
        public string identifier { get; set; }
        public string quality { get; set; }
    }
}