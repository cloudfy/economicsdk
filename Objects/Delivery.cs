namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Delivery : BaseObject
    {
        /// <summary></summary>
        public string address { get; set; }
        /// <summary></summary>
        public string zip { get; set; }
        /// <summary></summary>
        public string city { get; set; }
        /// <summary></summary>
        public string country { get; set; }
        /// <summary></summary>
        public string deliveryDate { get; set; }
        /// <summary></summary>
        public string deliveryTerms { get; set; }
    }
}