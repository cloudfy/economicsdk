namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Product : BaseObject
    {
        /// <summary></summary>
        public string barCode { get; set; }
        /// <summary></summary>
        public bool barred { get; set; }
        /// <summary></summary>
        public decimal costPrice { get; set; }
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public object inventory { get; set; }
        /// <summary></summary>
        public dynamic invoices { get; set; }
        /// <summary></summary>
        public string lastUpdated { get; set; }
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public string productNumber { get; set; }
        /// <summary></summary>
        public Unit unit { get; set; }
        /// <summary></summary>
        public decimal salesPrice { get; set; }
        /// <summary></summary>
        public decimal recommendedPrice { get; set; }

    }
}