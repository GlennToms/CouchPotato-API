using CouchPotato.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model.Movie;

namespace CouchPotato.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService()
        {
            _client = new HttpClient();
        }

        public MovieList GetMovies()
        {
            const string command = "/movie.list";

            var shows = _client.GetJson<MovieList>(command);

            return shows;
        }

        public MovieList GetMovies(Status status)
        {
            const string command = "/movie.list/?release_status=";

            var shows = _client.GetJson<MovieList>(command + status);

            return shows;
        }

        public Movie GetMovie(string title)
        {
            const string command = "/movie.list/?search=";

            var shows = _client.GetJson<MovieList>(command + title);

            var movie = new Movie()
            {
                IsSuccess = shows.IsSuccess,
                Total = shows.Total,
                IsEmpty = shows.IsEmpty,
                CategoryId = shows.Movies[0].CategoryId,
                Files = shows.Movies[0].Files,
                ID = shows.Movies[0].ID,
                Identifiers = shows.Movies[0].Identifiers,
                Info = shows.Movies[0].Info,
                ProfileId = shows.Movies[0].ProfileId,
                Releases = shows.Movies[0].Releases,
                Title = shows.Movies[0].Title,
                Type = shows.Movies[0].Type1,
                Type1 = shows.Movies[0].Type1,
                Revision = shows.Movies[0].Revision,
                Status = shows.Movies[0].Status
            };

            return movie;
        }
    }
}
