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

        public StatusCodes RefreshMovies()
        {
            const string command = "/movie.refresh";

            var shows = _client.GetJson<StatusCodes>(command);

            shows.Total = 0;
            shows.IsEmpty = false;

            return shows;
        }

        /// <summary>
        /// Add a movie to couchpotato
        /// </summary>
        /// <param name="identifier">Movie title to use for searches.Has to be one of the titles returned by MovieSearch.</param>
        /// <param name="profileId">ID of quality profile you want the add the movie in. If empty will use the default profile.</param>
        /// <param name="categoryId">ID of category you want the add the movie in. If empty will use no category.</param>
        /// <param name="force">Force readd even if movie already in wanted or manage</param>
        public Movie AddMovieByImdb(string identifier, string categoryId = null, string profileId = null, bool force = true)
        {
            const string command = "/movie.add";

            var newCommand = new StringBuilder(command);

            if (!string.IsNullOrWhiteSpace(identifier))
            {
                newCommand.Append("/?identifier=" + identifier);
            }

            if (!string.IsNullOrWhiteSpace(categoryId))
            {
                newCommand.Append("/?category_id=" + categoryId);
            }

            if (!string.IsNullOrWhiteSpace(profileId))
            {
                newCommand.Append("/?profile_id=" + profileId);
            }

            if (!force)
            {
                newCommand.Append("/?force=" + false);
            }

             var results = _client.GetJson<Movie>(newCommand.ToString());

            return results;
        }
    }
}
