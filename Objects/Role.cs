namespace EconomicSDK.Objects
{
    /// <summary>
    /// 
    /// </summary>
    public class Role
    {
        /// <summary></summary>
        public int roleNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>SuperUser,BookKeeping,Sales,ProjectEmployee</remarks>
        public string name { get; set; }
        /// <summary></summary>
        public object requiredModules { get; set; }
    }
}