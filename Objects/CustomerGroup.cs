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

}