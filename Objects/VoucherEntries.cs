using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{

    public class VoucherEntries
    {
        public Array financeVouchers { get; set; }
        public Array customerPayments { get; set; }
        public Array supplierInvoices { get; set; }
        public Array supplierPayments { get; set; }
        public Array manualCustomerInvoices { get; set; }
    }

}