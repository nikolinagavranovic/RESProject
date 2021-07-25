using Common.CommunicationModel;
using ModelPodataka.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Common.Repository
{
    public class SqlQueryExecutor : ISqlQueryExecutor
    {
        public SqlQueryExecutor()
        {
            context = new CommunicationBus_DbContext();
        }
        private CommunicationBus_DbContext context;
        public SqlQueryExecutor(CommunicationBus_DbContext context)
        {
            this.context = context;
        }

        ~SqlQueryExecutor()
        {
            context.Dispose();
        }
        public XmlDocument ExecuteSqlQuery(string sql)
        {
            Response responseModel = new Response();
            try
            {
                if (sql.Contains("SELECT") && sql.Contains("Resource"))
                {
                    var response = context.Resources.SqlQuery(sql).ToList();
                    if (response != null)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;
                        response.ForEach(x => responseModel.Payload += x.ToString() + "\n");
                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;
                        response.ForEach(x => responseModel.Payload += x.ToString() + "\n");
                    }
                }
                else if (sql.Contains("SELECT") && sql.Contains("Relation"))
                {
                    var response = context.Relations.SqlQuery(sql).ToList();
                    if (response != null)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;
                        response.ForEach(x => responseModel.Payload += x.ToString() + "\n");
                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;

                    }
                }
                else if (sql.Contains("SELECT") && sql.Contains("RelationType"))
                {
                    var response = context.RelationTypes.SqlQuery(sql).ToList();
                    if (response != null)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;
                        response.ForEach(x => responseModel.Payload += x.ToString() + "\n");
                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;
                        // responseModel.Payload = response;
                    }
                }
                else if (sql.Contains("SELECT") && sql.Contains("ResourceType"))
                {
                    var response = context.ResourceTypes.SqlQuery(sql).ToList();
                    if (response != null)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;
                        response.ForEach(x => responseModel.Payload += x.ToString() + "\n");
                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;
                    }
                }
                else
                {
                    int response = context.Database.ExecuteSqlCommand(sql);
                    if (response != 0)
                    {
                        responseModel.Status = EStatus.SUCCESS;
                        responseModel.StatusCode = (double)EStatus.SUCCESS;
                            
                    }
                    else
                    {
                        responseModel.Status = EStatus.REJECTED;
                        responseModel.StatusCode = (double)EStatus.REJECTED;
                    }
                }
                
            }
            catch (Exception e)
            {
                responseModel.Status = EStatus.REJECTED;
                responseModel.StatusCode = (int)EStatus.REJECTED;
                responseModel.Payload = e.Message;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Response));
            TextWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, responseModel);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(stringWriter.ToString());
            return xmlDocument;
        }
    }
}
