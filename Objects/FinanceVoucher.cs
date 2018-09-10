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
    public class FinanceVoucher : BaseObject
    {
        /// <summary></summary>
        public Account account { get; set; }
        /// <summary></summary>
        public VatAccount vatAccount { get; set; }
        /// <summary></summary>
        public string text { get; set; }
        /// <summary></summary>
        public Journal journal { get; set; }
        /// <summary></summary>
        public double? amount { get; set; }
        /// <summary></summary>
        public ContraAccount contraAccount { get; set; }
        /// <summary></summary>
        public Currency currency { get; set; }
        /// <summary></summary>
        public string date { get; set; }
        /// <summary></summary>
        public string entryType { get; set; }
        /// <summary></summary>
        public Voucher voucher { get; set; }
        public double? amountDefaultCurrency { get; set; }
        /// <summary></summary>
        public double? remainder { get; set; }
        /// <summary></summary>
        public double? remainderDefaultCurrency { get; set; }
        /// <summary></summary>
        public int? journalEntryNumber { get; set; }
        /// <summary></summary>
        public MetaData metaData { get; set; }        
    }

}