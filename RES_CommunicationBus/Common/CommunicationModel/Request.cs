using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationModel
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string Verb { get; set; }
        [DataMember]
        public string Noun { get; set; }
        [DataMember]
        public string Query { get; set; }
        [DataMember]
        public string Fields { get; set; }

        public Request(string verb, string noun, string query, string fields)
        {
            Verb = verb;
            Noun = noun;
            Query = query;
            Fields = fields;
        }
        public Request()
        {

        }
    }
}
