﻿using NUnit.Framework;
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
            Assert.IsTrue(result.Total > 5);
        }

        [Test]
        public void GetMovie_ByName_True()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.GetMovie("Zoolander");

            //Assert
            Assert.IsTrue(result.Title == "Zoolander");
        }

        [Test]
        public void GetMovie_ByStatus_True()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.GetMovies(Status.done);

            //Assert
            Assert.IsTrue(result.Movies.Count > 5);
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
        [TestCase("tt1431045", "","", false)]
        [TestCase("tt1431045", "", null, false)]
        [TestCase("tt1431045", null, "", false)]
        [TestCase("tt1431045", null, null, false)]
        public void AddMovieByImdb(string identifier, string categoryId, string profileId, bool force)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Movie.AddMovieByImdb(identifier, categoryId, profileId, force);

            //Assert
            Assert.IsTrue(result.IsSuccess);
        }
    }
}
