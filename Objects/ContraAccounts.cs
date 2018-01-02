using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{

    /// <summary></summary>
    public class ContraAccounts : BaseObject
    {
        /// <summary></summary>
        public AccountNumber customerPayments { get; set; }
        /// <summary></summary>
        public AccountNumber financeVouchers { get; set; }
        /// <summary></summary>
        public AccountNumber supplierPayments { get; set; }
    }

}