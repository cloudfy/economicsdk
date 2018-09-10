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
    public class Vouchers : BaseObject
    {
        /// <summary></summary>
        public int voucherNumber { get; set; }
        /// <summary></summary>
        public AccountingYear accountingYear { get; set; }
        /// <summary></summary>
        public Journal journal { get; set; }
        /// <summary></summary>
        public VoucherEntries entries { get; set; }
        /// <summary></summary>
        public string attachment { get; set; }
    }

}