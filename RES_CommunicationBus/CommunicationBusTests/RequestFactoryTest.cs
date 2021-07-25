using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebClient;
using WebClient.Adapters;

namespace CommunicationBusTests
{
    [TestClass]
    public class RequestFactoryTest
    {
        [TestMethod]
        [DataRow("GET/resurs")]
        [DataRow("POST/resurs")]
        [DataRow("PATCH/resurs")]
        [DataRow("DELETE/resurs")]
        public void TestMethod1(string str)
        {
            Request obj = RequestFactory.ConvertStringToRequest(str);

            Assert.IsNotNull(obj);  //proveravam da li je uopste uspelo
            var delovi = str.Split('/');
            Assert.AreEqual(obj.Verb, str[0]);
            Assert.AreEqual(obj.Noun, str[1]);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string str = "GETT/resurs";
            Request obj = RequestFactory.ConvertStringToRequest(str);

            Assert.IsNull(obj);  //proveravam da li je uopste uspelo
        }
    }
}
