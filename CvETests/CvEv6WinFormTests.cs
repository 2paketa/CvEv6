using Microsoft.VisualStudio.TestTools.UnitTesting;
using CvEv6WinForm;

namespace CvETests
{
    [TestClass]
    public class CvEv6WinFormTests
    {

        [TestMethod]
        public void ConnectivityStatusTest()
        {
            //
            var expected = true;
            //Act
            var actual = DataFromApi.IsApiOnline();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
