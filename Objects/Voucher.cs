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
    public class Voucher : BaseObject
    {
        public AccountingYear accountingYear { get; set; }
        public string attachment { get; set; }
        public int voucherNumber { get; set; }
    }

}