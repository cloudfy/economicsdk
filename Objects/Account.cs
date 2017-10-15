using System;
using System.Linq;
using System.Collections.Generic;

namespace EconomicSDK.Objects
{

    public class Account : BaseObject
    {
        public object accountingYears { get; set; }
        public int accountNumber { get; set; }
        public object accountType { get; set; }
        public object balance { get; set; }
        public object blockDirectEntries { get; set; }
        public object debitCredit { get; set; }
        public object name { get; set; }

    }

}