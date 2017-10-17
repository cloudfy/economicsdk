namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class CustomerGroup : BaseObject
    {
        /// <summary></summary>
        public int customerGroupNumber { get; set; }
        /// <summary></summary>
        public Account account { get; set; }
        /// <summary></summary>
        public string customers { get; set; }
        /// <summary></summary>
        public Layout layout { get; set; }
        /// <summary></summary>
        public string name { get; set; }        
    }

}