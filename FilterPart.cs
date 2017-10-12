using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK {
    
    /// <summary></summary>
    public class FilterPart
    {
        /// <summary></summary>
        public string propertyName { get; set; }
        /// <summary></summary>
        public object filterValue { get; set; }
        /// <summary></summary>
        public FilterTypeEnum filterType { get; set; }
    }

    /// <summary></summary>
    public enum FilterTypeEnum
    {
        /// <summary></summary>
        equal,
        /// <summary></summary>
        greatherthan,
        /// <summary></summary>
        lessthan,
        /// <summary></summary>
        lessthanorequal,
        /// <summary></summary>
        greatherthanorequal,
        /// <summary></summary>
        like,
        /// <summary></summary>
        inarray,
        /// <summary></summary>
        notinarray,
        /// <summary></summary>
        notequal
    }

    /// <summary></summary>
    public enum FilterEnum
    {
        /// <summary></summary>
        and,
        /// <summary></summary>
        or
    }
}
