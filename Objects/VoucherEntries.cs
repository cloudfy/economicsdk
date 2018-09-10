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
    public class VoucherEntries
    {
        /// <summary>
        /// 
        /// </summary>
        public VoucherEntries()
        {
            financeVouchers = new List<FinanceVoucher>();
        }
        /// <summary></summary>
        public IList<FinanceVoucher> financeVouchers { get; set; } // FinanceVoucher[] 

        //public Array customerPayments { get; set; }
        //public Array supplierInvoices { get; set; }
        //public Array supplierPayments { get; set; }
        //public Array manualCustomerInvoices { get; set; }
    }
}