using CouchPotato.Model;
using System;
using System.Net.Http;
using System.Text;
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
            if (!Enum.IsDefined(typeof(Status), status))
                throw new ArgumentOutOfRangeException(nameof(status), "Value should be defined in the Status enum.");

            const string command = "/movie.list/?release_status=";

            var shows = _client.GetJson<MovieList>(command + status);

            return shows;
        }

        public Movie GetMovie(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Value cannot be null or empty.", nameof(title));
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));

            

            const string command = "/movie.list/?search=";

            var shows = _client.GetJson<MovieList>(command + Util.ReplaceSpecial(title));

            var movie = new Movie()
            {
                IsSuccess = shows.IsSuccess,
                Total = shows.Total,
                IsEmpty = shows.IsEmpty
            };

            if (shows.Movies.Count > 0)
            {
                movie.CategoryId = shows.Movies[0].CategoryId;
                movie.Files = shows.Movies[0].Files;
                movie.ID = shows.Movies[0].ID;
                movie.Identifiers = shows.Movies[0].Identifiers;
                movie.Info = shows.Movies[0].Info;
                movie.ProfileId = shows.Movies[0].ProfileId;
                movie.Releases = shows.Movies[0].Releases;
                movie.Title = shows.Movies[0].Title;
                movie.Type = shows.Movies[0].Type1;
                movie.Type1 = shows.Movies[0].Type1;
                movie.Revision = shows.Movies[0].Revision;
                movie.Status = shows.Movies[0].Status;
            }

            return movie;
        }

        public StatusCodes RefreshMovies()
        {
            const string command = "/movie.refresh";

            var results =_client.GetJson<StatusCodes>(command);

            return results;
        }

        /// <summary>
        /// Add a movie to couchpotato
        /// </summary>
        /// <param name="identifier">Movie title to use for searches.Has to be one of the titles returned by MovieSearch.</param>
        /// <param name="profileId">ID of quality profile you want the add the movie in. If empty will use the default profile.</param>
        /// <param name="categoryId">ID of category you want the add the movie in. If empty will use no category.</param>
        /// <param name="force">Force readd even if movie already in wanted or manage</param>
        public MovieSingle AddMovieByImdb(string identifier, string categoryId = null, string profileId = null, bool force = true)
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

            var results = _client.GetJson<MovieSingle>(newCommand.ToString());

            return results;
        }

        public StatusCodes DeleteMovie(string id, DeleteFrom deleteFrom = DeleteFrom.all)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));
            if (!Enum.IsDefined(typeof(DeleteFrom), deleteFrom))
                throw new ArgumentOutOfRangeException(nameof(deleteFrom),
                    "Value should be defined in the DeleteFrom enum.");

            const string command = "/movie.delete?id=";

            var newCommand = new StringBuilder(command);

            newCommand.Append("?id=" + id);
            newCommand.Append("?delete_from=" + deleteFrom);

            var shows = _client.GetJson<StatusCodes>(newCommand.ToString());

            return shows;
        }

        public void StartSearch()
        {
            const string command = "/movie.searcher.full_search";

            _client.GetJson<StatusCodes>(command);
        }
    }
}
