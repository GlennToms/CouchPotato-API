using NUnit.Framework;

namespace CouchPotato.Tests.Services
{
    [TestFixture]
    public class ApiServiceTest
    {
        [Test]
        public void GetVersion_ReturnsV2()
        {
            //Arrange
            var client = new Client(AppSettings.Url, AppSettings.ApiKey);

            //Act
            var version = client.CouchPotato.GetVersion();

            //Assert
            Assert.AreEqual("v2", version.Release);
        }

        [Test]
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
