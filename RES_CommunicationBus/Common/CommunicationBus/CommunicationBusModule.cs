using Common.CommunicationModel;
using Common.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.CommunicationBus
{
    public class CommunicationBusModule
    {
        private XNode XmlRequest;
        private ISqlQueryExecutor sqlQueryExecutor;
        public CommunicationBusModule()
        {
            XmlRequest = null;
            sqlQueryExecutor = new SqlQueryExecutor();
        }

        public CommunicationBusModule(ISqlQueryExecutor sqe)
        {
            sqlQueryExecutor = sqe;
        }

        public string SendRequest(string jsonRequest)
        {
            XmlRequest = JsonConvert.DeserializeXNode(jsonRequest, "Request");
            XmlToSql xmlToSql = new XmlToSql();
            string sqlQuery = xmlToSql.Convert(XmlRequest);
            var xmlResponse = sqlQueryExecutor.ExecuteSqlQuery(sqlQuery);

            return JsonConvert.SerializeXmlNode(xmlResponse, Formatting.Indented);
        }
    }
}
