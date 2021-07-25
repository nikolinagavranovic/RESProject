using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient.Adapters
{
    public static class RequestFactory
    {
        public static Request ConvertStringToRequest(string stringRequest)
        {
            string[] partsOfRequest = stringRequest.Split('/');
            if (partsOfRequest[0] == "GET")
            {
            }
            else if (partsOfRequest[0] == "POST")
            {
            }
            else if (partsOfRequest[0] == "PATCH")
            {
            }
            else if (partsOfRequest[0] == "DELETE")
            {
            }
            else
            {
                return null;
            }

            Request request = new Request();
            request.Verb = partsOfRequest[0];
            request.Noun = partsOfRequest[1];

            return request;
        }
    }
}
