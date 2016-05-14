using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchPotato.Tests
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void WithHttpAndPortNoEndSlash()
        {
            //Arrange
            var client = new Client("http://Server01:6886", AppSettings.ApiKey);

            //Act
            var result = client.CouchPotato.IsAvaliable();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
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
