using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    public class AccountingYear : BaseObject
    {
        public string entries { get; set; }
        public string periods { get; set; }
        public string totals { get; set; }
        public string year { get; set; }
        public string vouchers { get; set; }
        public bool closed { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
