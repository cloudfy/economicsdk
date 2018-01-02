using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{

    public class Vouchers
    {
        public int voucherNumber { get; set; }
        public AccountingYear accountingYear { get; set; }
        public Journal journal { get; set; }
        public VoucherEntries entries { get; set; }
    }

}