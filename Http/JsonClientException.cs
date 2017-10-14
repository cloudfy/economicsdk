using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EconomicSDK
{

    /// <summary></summary>
    public class JsonClientException : Exception
    {
        private System.Net.HttpStatusCode _statusCode;

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public JsonClientException(string message, System.Net.HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return _statusCode;
            }
        }
    }

}