using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class VatAccount : BaseObject
    {
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public string vatCode { get; set; }
        /// <summary></summary>
        public decimal ratePercentage { get; set; }
        /// <summary></summary>
        public Account account { get; set; }
        /// <summary></summary>
        public bool barred { get; set; }
        /// <summary></summary>
        public object contraAccount { get; set; }
    }
}