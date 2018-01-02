using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{

    /// <summary></summary>
    public class JournalSettings : BaseObject
    {
        /// <summary></summary>
        public ContraAccounts contraAccounts { get; set; }
        /// <summary></summary>
        public entryTypeRestrictedToEnum entryTypeRestrictedTo { get; set; }
        /// <summary></summary>
        public VoucherNumbers voucherNumbers { get; set; }
    }

}