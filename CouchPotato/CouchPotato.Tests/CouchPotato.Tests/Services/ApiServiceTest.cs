using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CouchPotato.Tests
{
    [TestClass]
    public class ApiServiceTest
    {
        [TestMethod]
        public void GetVersion_ReturnsV2()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var version = client.CouchPotato.GetVersion();

            //Assert
            Assert.AreEqual("v2", version.Release);
        }

        [TestMethod]
        public void IsAvaliable_ReturnsTrue()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.CouchPotato.IsAvaliable();

            //Assert
            Assert.IsTrue(result);
        }
    }
}
