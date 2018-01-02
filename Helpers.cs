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
    /// <summary>Economic SDK Helper methods.</summary>
    internal class Helpers
    {
        /// <summary>
        /// Collects filters for query.
        /// </summary>
        /// <param name="parts"></param>
        /// <param name="filter"></param>
        /// <returns>string</returns>
        internal static string CollectFilters(FilterPart[] parts, FilterEnum filter)
        {
            if (parts == null)
                throw new ArgumentNullException();

            string output = "";
            foreach (var part in parts)
            {
                if (output != "")
                {
                    if (filter == FilterEnum.and)
                        output += "$and:";
                    if (filter == FilterEnum.or)
                        output += "$or:";
                }

                output += part.propertyName;
                if (part.filterType == FilterTypeEnum.equal)
                    output += "$eq:";
                if (part.filterType == FilterTypeEnum.notequal)
                    output += "$ne:";
                if (part.filterType == FilterTypeEnum.greatherthan)
                    output += "$gt:";
                if (part.filterType == FilterTypeEnum.lessthan)
                    output += "$lt:";
                if (part.filterType == FilterTypeEnum.lessthanorequal)
                    output += "$lte:";
                if (part.filterType == FilterTypeEnum.greatherthanorequal)
                    output += "$gte:";
                if (part.filterType == FilterTypeEnum.like)
                    output += "$like:";
                if (part.filterType == FilterTypeEnum.inarray)
                    output += "$in:";
                if (part.filterType == FilterTypeEnum.notinarray)
                    output += "$nin:";

                output += part.filterValue.ToString();
            }

            return output;
        }
    }
}
