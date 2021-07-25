using System;
using Common.CommunicationModel;
using Common.Helpers;
using Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommunicationBusTests
{
    [TestClass]
    public class RequestFactoryTests
    {
        [TestMethod]
        [DataRow("GET/resurs/1")]
        [DataRow("GET/Resources//Name='Petar';Description='opis'/Name;Description")]
        [DataRow("GET/Resources//Name='Petar';Description='opis'")]
        //GET/Resources//Name='Petar';Description='opis'/Name;Description
        //GET/Resources//Name='Petar';Description='opis'"
        public void ConvertStringToRequest_MakingRequest_ReturnNotNullValue(string stringRequest)
        { 
            Request request = RequestFactory.ConvertStringToRequest(stringRequest);

            Assert.IsNotNull(request);
        }
       
    } 
}
