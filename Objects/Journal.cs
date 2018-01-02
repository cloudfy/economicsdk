using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Journal : BaseObject
    {
        /// <summary></summary>
        public string entries { get; set; }
        /// <summary></summary>
        public int journalNumber { get; set; }
        /// <summary></summary>
        public object metaData { get; set; }
        /// <summary></summary>
        [Required]
        public string name { get; set; }
        /// <summary></summary>
        public JournalSettings settings { get; set; }
        /// <summary></summary>
        public Templates templates { get; set; }
        /// <summary></summary>
        public string vouchers { get; set; }
    }

    /// <summary></summary>
    public enum entryTypeRestrictedToEnum : int
    {
        financeVoucher,
        supplierInvoice,
        supplierPayment,
        customerPayment,
        manualCustomerInvoice
    }
}
