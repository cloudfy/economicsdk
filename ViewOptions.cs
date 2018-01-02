using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// Providers view options for pagination.
    /// </summary>
    public class ViewOptions
    {
        #region === constructor ===
        /// <summary>
        /// 
        /// </summary>
        public ViewOptions() : this(20,0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="skipPages"></param>
        public ViewOptions(int pageSize, int skipPages)
        {
            if (PageSize > 1000)
                throw new ArgumentOutOfRangeException("Maximum page size of 1.000.");

            this.PageSize = pageSize;
            this.SkipPages = skipPages;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }
        public int SkipPages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void AppendTo(ref string url)
        {
            if (!url.Contains("?"))
            {
                url += "?";
            } else
            {
                url += "&";
            }

            url += string.Format("skippages={1}&pagesize={0}", this.PageSize, this.SkipPages);
        }
    }
}
