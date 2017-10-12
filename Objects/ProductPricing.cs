namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class ProductPricing : BaseObject
    {
        /// <summary></summary>
        public Currency currency { get; set; }
        /// <summary></summary>
        public decimal price { get; set; }
        /// <summary></summary>
        public Product product { get; set; }
    }
}
