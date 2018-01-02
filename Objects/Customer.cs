namespace EconomicSDK.Objects
{
    /// <summary></summary>
    /// <remarks>https://restapi.e-conomic.com/schema/customers.get.schema.json#_ga=2.194911405.1672410647.1498480545-669799220.1496955321</remarks>
    public class Customer : BaseObject
    {
        #region === constructor ===
        /// <summary></summary>
        public Customer()
        {
        }
        #endregion

        #region === properties ===
        /// <summary></summary>
        [Required]
        public string currency { get; set; }
        /// <summary></summary>
        [Required]
        public string name { get; set; }
        /// <summary></summary>
        public string address { get; set; }
        /// <summary></summary>
        [Required]
        public CustomerGroup customerGroup { get; set; }
        /// <summary></summary>
        [Required]
        public PaymentTerms paymentTerms { get; set; }
        /// <summary></summary>
        public decimal balance { get; set; }
        /// <summary></summary>
        public bool barred { get; set; }
        /// <summary></summary>
        public string city { get; set; }
        /// <summary>Corporate Identification Number. For example CVR in Denmark.</summary>
        public string corporateIdentificationNumber { get; set; }
        /// <summary></summary>
        public string country { get; set; }
        /// <summary></summary>
        public string ean { get; set; }
        /// <summary></summary>
        public string email { get; set; }
        /// <summary></summary>
        public string lastUpdated { get; set; }
        /// <summary>The public entry number is used for electronic invoicing, to define the account invoices will be registered on at the customer.</summary>
        public string publicEntryNumber { get; set; }
        /// <summary></summary>
        public string telephoneAndFaxNumber { get; set; }
        /// <summary></summary>
        public string vatNumber { get; set; }
        /// <summary></summary>
        public string website { get; set; }
        /// <summary></summary>
        public string zip { get; set; }
        /// <summary></summary>
        public string contacts { get; set; }
        /// <summary></summary>
        public string deliveryLocations { get; set; }
        /// <summary></summary>
        public Attention attention { get; set; }
        /// <summary></summary>
        public CustomerContact customerContact { get; set; }
        /// <summary></summary>
        public Layout layout { get; set; }
        /// <summary></summary>
        public Person salesPerson { get; set; }
        /// <summary></summary>
        public Templates templates { get; set; }
        /// <summary></summary>
        public decimal creditLimit { get; set; }
        /// <summary></summary>
        public int? customerNumber { get; set; }
        /// <summary></summary>
        [Required]
        public VatZone vatZone { get; set; } 
        #endregion
    }
}
