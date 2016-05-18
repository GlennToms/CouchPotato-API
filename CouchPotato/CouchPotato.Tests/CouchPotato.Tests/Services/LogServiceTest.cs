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
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void GetLogs_ByLines(int lines)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Log.GetLogs(lines);

            //Assert
            Assert.AreEqual(result.Log.Count, lines);
        }

        [Test]
        [TestCase(Type.all)]
        [TestCase(Type.error)]
        [TestCase(Type.info)]
        public void GetLogs_ByType(Type type)
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var result = client.Log.GetLogs(type);

            //Assert
            Assert.IsTrue(result.Total > 0);
        }
    }
}
