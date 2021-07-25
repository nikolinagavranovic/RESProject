using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.CommunicationBus
{
    public class XmlToSql
    {
        public XmlToSql()
        {

        }

        public string Convert(XNode xml)
        {
            XElement request = xml.Document.Element("Request");
            string method = request.Element("Verb").Value.ToString();
            if(method == "GET")
            {
                return GenerateGetSQL(request);
            }
            else if(method == "PATCH")
            {
                return GeneratePatchSQL(request);
            }
            else if(method == "POST")
            {
                return GeneratePostSQL(request);
            }
            else if(method == "DELETE")
            {
                return GenerateDeleteSQL(request);
            }

            return "";
        }

        //GET/Resources//Name='Petar';Description='opis'/Name;Description
        //GET/Resources//Name='Petar';Description='opis'"
        //GET/Resources/1
        private string GenerateGetSQL(XElement request)
        {
            string sqlQuery = "";
            string noun = request.Element("Noun").Value;
            string query = request.Element("Query").Value;
            string fields = request.Element("Fields").Value;

            if (string.IsNullOrEmpty(fields))
            {
                fields = "*";
            }
            else
            {
                fields = fields.Replace(";", ",");
            }

            string[] nounParts = noun.Split('/');
            sqlQuery = $"SELECT {fields} FROM {nounParts[0]} WHERE ";
            if(!string.IsNullOrEmpty(nounParts[1]))
            {
                sqlQuery += $"Id = {nounParts[1]}";
            }

            if (string.IsNullOrEmpty(query))
            {
                query = "";
            }
            else if(!noun.Contains("Id"))
            {
                query = query.Replace(";", " and ");
            }
            else
            {
                query = " and " + query.Replace(";", " and ");
            }

            sqlQuery += $"{query};";

            return sqlQuery;
        }

        //POST/Resources//Name;Description/'Milan';'Description'
        private string GeneratePostSQL(XElement request)
        {
            string sqlQuery = "";
            string noun = request.Element("Noun").Value.Split('/')[0];
            string query = request.Element("Query").Value;
            string fields = request.Element("Fields").Value;

            sqlQuery = $"INSERT Into {noun} ({query.Replace(";", ", ")}) VALUES ({fields.Replace(";", ", ")});";

            return sqlQuery;
        }

        //"PATCH/Resources//Name='Milan'/Name='Marko'"
        private string GeneratePatchSQL(XElement request)
        {
            string sqlQuery = "";
            string noun = request.Element("Noun").Value.Split('/')[0];
            string query = request.Element("Query").Value;
            string fields = request.Element("Fields").Value;
            string[] nounSplited = noun.Split('/');

            sqlQuery = $"UPDATE {nounSplited[0]} SET {fields.Replace(";", ",")} WHERE {query.Replace(";", " and ")};";
            
            return sqlQuery;
        }

        //DELETE/Resources//Name='Milan';Description='opis'
        private string GenerateDeleteSQL(XElement request)
        {
            string sqlQuery = "";
            string noun = request.Element("Noun").Value.Split('/')[0];
            string query = request.Element("Query").Value;
            string fields = request.Element("Fields").Value;
            string[] nounSplited = noun.Split('/');

            sqlQuery = $"DELETE FROM {nounSplited[0]} WHERE {query.Replace(";", " and ")};";

            return sqlQuery;
        }
    }
}