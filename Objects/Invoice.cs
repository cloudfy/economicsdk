namespace EconomicSDK.Objects
{

    /// <summary></summary>
    public class Invoice : BaseObject
    {
        /// <summary></summary>
        public Invoice()
        {
            lines = new InvoiceLine[] { };
            grossAmount = 0;
            netAmount = 0;
            //exchangeRate = 100;
            marginInBaseCurrency = 0;
            marginPercentage = 0;
            vatAmount = 0;
            roundingAmount = 0;
            netAmountInBaseCurrency = 0;
            costPriceInBaseCurrency = 0;
        }
        /// <summary></summary>
        public int draftInvoiceNumber { get; set; }
        /// <summary></summary>
        public int bookedInvoiceNumber { get; set; }
        /// <summary></summary>
        [Required]
        public string currency { get; set; }
        /// <summary></summary>
        [Required]
        public Customer customer { get; set; }
        /// <summary></summary>
        [Required]
        public string date { get; set; }
        /// <summary></summary>
        public Delivery delivery { get; set; }
        /// <summary></summary>
        public DeliveryLocation deliveryLocation { get; set; }
        /// <summary></summary>
        public string dueDate { get; set; }
        /// <summary></summary>
        public decimal? exchangeRate { get; set; }
        /// <summary></summary>
        public decimal grossAmount { get; set; }
        /// <summary></summary>
        public decimal roundingAmount { get; set; }
        /// <summary></summary>
        public decimal vatAmount { get; set; }
        /// <summary></summary>
        public Layout layout { get; set; }
        /// <summary></summary>
        public InvoiceLine[] lines { get; set; }
        /// <summary></summary>
        public decimal marginInBaseCurrency { get; set; }
        /// <summary></summary>
        public decimal marginPercentage { get; set; }
        /// <summary></summary>
        public decimal netAmount { get; set; }
        /// <summary></summary>
        public Notes Notes { get; set; }
        /// <summary></summary>
        public PaymentTerms paymentTerms { get; set; }
        /// <summary></summary>
        public Recipient recipient { get; set; }
        /// <summary></summary>
        public Reference references { get; set; }
        /// <summary></summary>
        public Project project { get; set; }
        /// <summary></summary>
        public decimal netAmountInBaseCurrency { get; set; }
        /// <summary></summary>
        public decimal costPriceInBaseCurrency { get; set; }
    }
}