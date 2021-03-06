using System;
using System.Linq;
using System.Collections.Generic;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Account : AccountNumber
    {
        /// <summary></summary>
        public object accountingYears { get; set; }
        /// <summary></summary>
        public object accountType { get; set; }
        /// <summary></summary>
        public object balance { get; set; }
        /// <summary></summary>
        public object blockDirectEntries { get; set; }
        /// <summary></summary>
        public object debitCredit { get; set; }
        /// <summary></summary>
        public object name { get; set; }
    }

    /// <summary></summary>
    public class AccountNumber : BaseObject
    {
        /// <summary></summary>
        public int accountNumber { get; set; }
    }
}