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
