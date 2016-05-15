
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Tests
{
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void WithHttpAndPortNoEndSlash()
        {
            //Arrange
            var client = new Client("http://Server01:6886", AppSettings.ApiKey);

            //Act
            var result = client.CouchPotato.IsAvaliable();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void WithHttpAndPortEndSlash()
        {
            //Arrange
            var client = new Client("http://Server01:6886/", AppSettings.ApiKey);

            //Act
            var result = client.CouchPotato.IsAvaliable();

            //Assert
            Assert.IsTrue(result);
        }
    }
}
