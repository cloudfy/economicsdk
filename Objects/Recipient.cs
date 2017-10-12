namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Recipient : BaseObject
    {
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public string address { get; set; }
        /// <summary></summary>
        public string zip { get; set; }
        /// <summary></summary>
        public string city { get; set; }
        /// <summary></summary>
        public string country { get; set; }
        /// <summary></summary>
        public string ean { get; set; }
        /// <summary></summary>
        public string publicEntryNumber { get; set; }
        /// <summary></summary>
        public Attention attention { get; set; }
        /// <summary></summary>
        public VatZone vatZone { get; set; }
    }
}