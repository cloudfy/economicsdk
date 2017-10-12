namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class InvoiceLine
    {
        public InvoiceLine()
        {
            discountPercentage = 0;
            this.sortKey = 1;
        }
        /// <summary></summary>
        public int? lineNumber { get; set; }
        /// <summary></summary>
        public int sortKey { get; set; }
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public Accrual accrual { get; set; }
        /// <summary></summary>
        public Unit unit { get; set; }
        /// <summary></summary>
        public Product product { get; set; }
        /// <summary></summary>
        public decimal? quantity { get; set; }
        /// <summary></summary>
        public decimal? unitNetPrice { get; set; }
        /// <summary></summary>
        public decimal? discountPercentage { get; set; }
        /// <summary></summary>
        public decimal? unitCostPrice { get; set; }
        /// <summary></summary>
        public decimal? marginInBaseCurrency { get; set; }
        /// <summary></summary>
        public decimal? marginPercentage { get; set; }
    }
}