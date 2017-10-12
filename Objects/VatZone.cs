namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class VatZone : BaseObject
    {
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public int vatZoneNumber { get; set; }
        /// <summary></summary>
        public bool enabledForCustomer { get; set; }
        /// <summary></summary>
        public bool enabledForSupplier { get; set; }
    }
}