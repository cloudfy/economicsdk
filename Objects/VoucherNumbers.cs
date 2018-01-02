using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{

    /// <summary></summary>
    public class VoucherNumbers : BaseObject
    {
        /// <summary></summary>
        public int maximumVoucherNumber { get; set; }
        /// <summary></summary>
        public int minimumVoucherNumber { get; set; }
    }

}