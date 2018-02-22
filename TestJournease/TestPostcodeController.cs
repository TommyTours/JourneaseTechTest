using System.Linq;
using JourneaseTechTest.AppCode;
using JourneaseTechTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace TestJournease
{
    [TestClass]
    public class TestPostcodeController
    {
        static BingMapsProvider provider = new BingMapsProvider();
        private static PostcodeController controller = new PostcodeController(provider);
        [TestMethod]
        public void TestExistsTrueBS163RY()
        {
            Assert.AreEqual("true", controller.Exists("BS16 3RY"));
        }

        [TestMethod]
        public void TestExistsTrueNP190PN()
        {
            Assert.AreEqual("true", controller.Exists("NP19 0PN"));
        }

        [TestMethod]
        public void TestExistsTrueBS216YW()
        {
            Assert.AreEqual("true", controller.Exists("BS21 6YW"));
        }

        [TestMethod]
        public void TestExistsFalse()
        {
            Assert.AreEqual("false", controller.Exists("BSDGE2342342"));
        }

        [TestMethod]
        public void TestGetCoordinates()
        {
            var testCoordinates = controller.GetCoordinates("BS16 3RY");
            JObject jsonData = JObject.Parse(testCoordinates);
            Assert.AreEqual((decimal)51.4770851135254, jsonData["latitude"]);
            Assert.AreEqual((decimal)-2.52708101272583, jsonData["longitude"]);
        }

    }
}
