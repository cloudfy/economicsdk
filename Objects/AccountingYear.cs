using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    public class AccountingYear : BaseObject
    {
        public bool closed { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
