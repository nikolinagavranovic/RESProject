using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;

namespace CommunicationBusTests
{

    [TestClass]
    public class ValidationOfRequestTests
    {
        [TestMethod]
        public void ValidateRequest_PassTheCheck_ReturnTrue()
        {
            string stringRequest = "POST/resurs/1";
            var validation = new ValidationOfRequest();

            var result = validation.ValidateRequest(stringRequest);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateRequest_PassTheCheck_ReturnFalse()
        {
            string stringRequest = "POStT/resurs/1";
            var validation = new ValidationOfRequest();

            var result = validation.ValidateRequest(stringRequest);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateRequest_ResourceNameDoesNotExist_ReturnFalse()
        {
            string stringRequest = "GET/";

            ValidationOfRequest validation = new ValidationOfRequest();
            var result = validation.ValidateRequest(stringRequest);


            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ValidateRequest_GenerateConstructor_ReturnNotNull()
        {
            ValidationOfRequest validation = new ValidationOfRequest();

            Assert.IsNotNull(validation);
        }

        [TestMethod]
        [DataRow("GET/")]
        [DataRow("GETT/asdf")]
        [DataRow("GET/asdf/asdf/asdf/asdf/asdf/asdf")]
        public void ValidateRequest_Errors(string request)
        {
            ValidationOfRequest validation = new ValidationOfRequest();

            var result = validation.ValidateRequest(request);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("GET/Resurs/1")]
        public void ValidateRequest_Success(string request)
        {
            ValidationOfRequest validation = new ValidationOfRequest();

            var result = validation.ValidateRequest(request);

            Assert.IsTrue(result);
        }
    }
}
