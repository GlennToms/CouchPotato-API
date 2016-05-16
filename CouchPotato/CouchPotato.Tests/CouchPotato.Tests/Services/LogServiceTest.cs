using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Type = CouchPotato.Model.Logging.Type;

namespace CouchPotato.Tests.Services
{
    [TestFixture]
    public class LogServiceTest
    {
        [Test]
        public void GetLogs()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Log.GetLogs();

            //Assert
            Assert.IsTrue(result.Total > 0);
        }

        [Test]
        public void GetLogs_ByLines()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Log.GetLogs(3);

            //Assert
            Assert.AreEqual(result.Log.Count, 3);
        }

        [Test]
        public void GetLogs_ByType()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Log.GetLogs(Type.error);

            //Assert
            Assert.IsTrue(result.Total > 5);
        }
    }
}
