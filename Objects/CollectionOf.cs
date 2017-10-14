using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public abstract class CollectionOf<T> : BaseObject
    {
        /// <summary></summary>
        public T[] collection { get; set; }
        /// <summary></summary>
        public Pagination pagination { get; set; }
        /// <summary></summary>
        public MetaData metaData { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MetaData
    {
        /// <summary></summary>
        public CreateMeta create { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CreateMeta
    {
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public string href { get; set; }
        /// <summary></summary>
        public string httpMethod { get; set; }
    }

}
