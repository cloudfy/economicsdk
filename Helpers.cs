using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    internal class Helpers
    {
        /// <summary></summary>
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
