using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    class ErrorMessage
    {
        /// <summary></summary>
        public string message { get; set; }
        /// <summary></summary>
        public string errorCode { get; set; }
        /// <summary></summary>
        public string developerHint { get; set; }
        /// <summary></summary>
        public Guid logId { get; set; }
        /// <summary></summary>
        public int httpStatusCode { get; set; }
        /// <summary></summary>
        public string[] errors { get; set; }
        /// <summary></summary>
        public DateTime logTime { get; set; }
        /// <summary></summary>
        public string schemaPath { get; set; }
    }
}
