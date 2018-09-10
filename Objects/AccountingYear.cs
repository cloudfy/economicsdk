using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class AccountingYear : BaseObject
    {
        /// <summary></summary>
        public string entries { get; set; }
        /// <summary></summary>
        public string periods { get; set; }
        /// <summary></summary>
        public string totals { get; set; }
        /// <summary></summary>
        public string year { get; set; }
        /// <summary></summary>
        public string vouchers { get; set; }
        /// <summary></summary>
        public bool? closed { get; set; }
        /// <summary></summary>
        public string fromDate { get; set; }
        /// <summary></summary>
        public string toDate { get; set; }
    }
}
