using System;
using System.Linq;
using System.Collections.Generic;
using EconomicSDK.Objects;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCollectionOf<T> : BaseObject
    {
        /// <summary></summary>
        public T[] collection { get; set; }
        /// <summary></summary>
        public Pagination pagination { get; set; }
        /// <summary></summary>
        public MetaData metaData { get; set; }
    }

}