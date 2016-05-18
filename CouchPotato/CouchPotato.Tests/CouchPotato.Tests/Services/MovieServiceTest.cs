using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouchPotato.Model.Movie;

namespace CouchPotato.Tests.Services
{
    [TestFixture]
    class MovieServiceTest
    {
        [Test]
        public void GetMovies_GreaterThan5_True()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.GetMovies();

            //Assert
            Assert.IsTrue(result.Total > 1);
        }

        [Test]
        [TestCase("3:10 to Yuma")]
        [TestCase("Zoolander")]
        [TestCase("Ant-Man")]
        [TestCase("After Earth")]
        public void GetMovie_ByName(string name)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.GetMovie(name);

            //Assert
            Assert.AreEqual(result.Title.ToLower(), name.ToLower());
        }

        [Test]
        [TestCase(Status.active)]
        [TestCase(Status.available)]
        [TestCase(Status.done)]
        [TestCase(Status.snached)]
        public void GetMovie_ByStatus_True(Status status)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.GetMovies(status);

            //Assert
            Assert.IsTrue(result.Movies.Count > 0);
        }

        [Test]
        public void RefreshMovies()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.RefreshMovies();

            //Assert
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        [TestCase("tt1431045", "","", true)]
        [TestCase("tt1431045", "", null, false)]
        [TestCase("tt1431045", null, "", true)]
        [TestCase("tt1431045", null, null, false)]
        public void AddMovieByImdb(string identifier, string categoryId, string profileId, bool force)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.AddMovieByImdb(identifier, categoryId, profileId, force);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.ID == "51cd36cbed40482e86a39a04033fef03");
            Assert.IsTrue(result.Title == "Deadpool");
        }

        [Test]
        [TestCase("51cd36cbed40482e86a39a04033fef03",DeleteFrom.all)]
        public void DeleteMovie(string id, DeleteFrom deleteFrom)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.DeleteMovie(id, deleteFrom);

            //Assert
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
