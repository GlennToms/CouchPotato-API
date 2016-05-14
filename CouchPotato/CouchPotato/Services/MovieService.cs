using CouchPotato.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService()
        {
            _client = new HttpClient();
        }

        public IEnumerable<Movie> GetMovies()
        {
            const string command = "?cmd=shows&sort=name";

            var shows = _client.Get<Dictionary<string, Movie>>(command);

            return shows.Values;
        }

    }
}
