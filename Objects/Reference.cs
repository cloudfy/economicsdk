using System;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Reference : BaseObject
    {
        /// <summary></summary>
        public string other { get; set; }
        /// <summary></summary>
        public Employee salesPerson { get; set; }
        /// <summary></summary>
        public Employee vendorReference { get; set; }
        /// <summary></summary>
        public CustomerContact customerContact { get; set; }

    }
}