using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommunicationModel
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public EStatus Status { get; set; }
        [DataMember]
        public double StatusCode { get; set; }
        [DataMember]
        public string Payload { get; set; }

        public Response(EStatus status, double statusCode, string payload)
        {
            Status = status;
            StatusCode = statusCode;
            Payload = payload;
        }
        public Response()
        {
        }
    }
}
