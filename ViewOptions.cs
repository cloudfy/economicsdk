/*  
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>. 
*/

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

        #region === public properties ===
        /// <summary>
        /// Gets or sets the page size of the pagination.
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the number of pages to skip.
        /// </summary>
        public int SkipPages { get; set; }
        #endregion

        #region === public methods ===
        /// <summary>
        /// Append to the url.
        /// </summary>
        /// <param name="url">Url of the request.</param>
        public void AppendTo(ref string url)
        {
            if (!url.Contains("?"))
            {
                url += "?";
            }
            else
            {
                url += "&";
            }

            url += string.Format("skippages={1}&pagesize={0}", this.PageSize, this.SkipPages);
        } 
        #endregion
    }
}
