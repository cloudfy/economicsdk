namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Invoices : BaseObject
    {
        /// <summary></summary>
        public string drafts { get; set; }
        /// <summary></summary>
        public string booked { get; set; }
        /// <summary></summary>
        public string paid { get; set; }
        /// <summary></summary>
        public string unpaid { get; set; }
        /// <summary></summary>
        public string overdue { get; set; }
        /// <summary></summary>
        public string notDue { get; set; }
        /// <summary></summary>
        public string totals { get; set; }
    }
}