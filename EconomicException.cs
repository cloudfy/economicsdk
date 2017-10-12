using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace EconomicSDK
{
    /// <summary>
    /// 
    /// </summary>

    [Serializable]
    public class EconomicException : Exception
    {
        private ErrorMessage eo;
        private JsonClientException e;

        /// <summary>
        /// 
        /// </summary>
        public EconomicException()
        {
        }

        public EconomicException(string message) : base(message)
        {
        }

        public EconomicException(ErrorMessage eo, JsonClientException e) : base(eo.message)
        {
            this.eo = eo;
            this.e = e;
        }

        public EconomicException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EconomicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ErrorMessage ErrorMessage
        {
            get
            {
                return eo;
            }
        }
    }

}