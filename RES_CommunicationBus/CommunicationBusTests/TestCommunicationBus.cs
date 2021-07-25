using Common.CommunicationBus;
using Common.Mocks;
using Common.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationBusTests
{
    [TestClass]
    public class TestCommunicationBus
    {
        [TestMethod]
        public void Test1()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": null,\"Fields\": null}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test2()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test3()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"POST\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test4()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"DELETE\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test5()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"GET\",\"Noun\": \"Resources/2\",\"Query\": null,\"Fields\": null}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test6()
        {
            ISqlQueryExecutor sqlQueryExecutor = new SqlExecutorMock();
            CommunicationBusModule cbm = new CommunicationBusModule(sqlQueryExecutor);
            string json = "{\"Verb\": \"PATCH\",\"Noun\": \"Resources/2\",\"Query\": \"name='pera'\",\"Fields\": \"*\"}";
            string response = cbm.SendRequest(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestCTOR()
        {
            CommunicationBusModule cbm = new CommunicationBusModule();

            Assert.IsNotNull(cbm);
        }
    }
}
