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
        #region === member variables ===
        /// <summary></summary>
        private ErrorMessage eo;
        /// <summary></summary>
        private JsonClientException e; 
        #endregion

        #region === constructor ===
        /// <summary>
        /// 
        /// </summary>
        public EconomicException()
        {
        }
        /// <summary></summary>
        public EconomicException(string message) : base(message)
        {
        }
        /// <summary></summary>
        public EconomicException(ErrorMessage eo, JsonClientException e) : base(eo.message)
        {
            this.eo = eo;
            this.e = e;
        }
        /// <summary></summary>
        public EconomicException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary></summary>
        protected EconomicException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion

        #region === properties ===
        /// <summary></summary>
        public ErrorMessage ErrorMessage
        {
            get
            {
                return eo;
            }
        } 
        #endregion
    }

}