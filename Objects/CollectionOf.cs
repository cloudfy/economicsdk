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

    public class MetaData
    {
        public CreateMeta create { get; set; }
    }

    public class CreateMeta
    {
        public string description { get; set; }
        public string href { get; set; }
        public string httpMethod { get; set; }
    }

}
