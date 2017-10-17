namespace EconomicSDK.Objects
{
    /// <summary>A schema for retrieval of a single vat zone.</summary>
    public class VatZone : BaseObject
    {
        /// <summary>The name of the vat zone.</summary>
        public string name { get; set; }
        /// <summary>A unique identifier of the vat zone.</summary>
        public int vatZoneNumber { get; set; }
        /// <summary>If this value is true, then the vat zone can be used for a customer.</summary>
        public bool enabledForCustomer { get; set; }
        /// <summary>If this value is true, then the vat zone can be used for a supplier.</summary>
        public bool enabledForSupplier { get; set; }
    }
}