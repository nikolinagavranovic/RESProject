using Common.CommunicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common.Helpers
{
    public class RequestFactory
    {
        public static Request ConvertStringToRequest(string stringRequest)
        {
            string[] partsOfRequest = stringRequest.Split('/');
            Request request = new Request();
            request.Verb = partsOfRequest[0];
            request.Noun = partsOfRequest[1] +"/"+ partsOfRequest[2];
            if(partsOfRequest.Length >= 4)
            {
                request.Query = partsOfRequest[3];
            }
            if (partsOfRequest.Length >= 5)
            {
                request.Fields = partsOfRequest[4];
            }
            return request;
        }
    }
}
