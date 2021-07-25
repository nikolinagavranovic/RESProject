using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ValidationOfRequest
    {
        public bool ValidateRequest(string request)
        {
            string[] partsOfRequest = request.Split('/');
            List<string> methods = new List<string> { "GET", "POST", "PATCH", "DELETE" };
            
            if(!methods.Contains(partsOfRequest[0]))
            {
                return false;
            }
            if(partsOfRequest.Length > 5 || partsOfRequest.Length < 1)
            {
                return false;
            }

            int i = 0;
            foreach(string element in partsOfRequest)
            {
                if(string.IsNullOrEmpty(element) && i != 2)
                {
                    return false;
                }
                i++;
            }

            return true;
        }

        public ValidationOfRequest()
        {
        }
    }
}
    
