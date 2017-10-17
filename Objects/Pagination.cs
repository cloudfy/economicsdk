using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class Pagination
    {
        /// <summary></summary>
        public int maxPageSizeAllowed { get; set; }
        /// <summary></summary>
        public int skipPages { get; set; }
        /// <summary></summary>
        public int pageSize { get; set; }
        /// <summary></summary>
        public int results { get; set; }
        /// <summary></summary>
        public int resultsWithoutFilter { get; set; }
        /// <summary></summary>
        public string firstPage { get; set; }
        /// <summary></summary>
        public string lastPage { get; set; }
    }
}
