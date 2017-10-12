namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class CustomerGroup : BaseObject
    {
        /// <summary></summary>
        public int customerGroupNumber { get; set; }

        public Account account { get; set; }
        public string customers { get; set; }
        public Layout layout { get; set; }
        public string name { get; set; }        
    }

    public class Account : BaseObject
    {
        public object accountingYears { get; set; }
        public object accountNumber { get; set; }
        public object accountType { get; set; }
        public object balance { get; set; }
        public object blockDirectEntries { get; set; }
        public object debitCredit { get; set; }
        public object name { get; set; }

    }
}