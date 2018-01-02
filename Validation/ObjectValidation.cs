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
using System.Reflection;

namespace EconomicSDK.Validation
{
    /// <summary>
    /// Provides common methods for object validation.
    /// </summary>
    internal static class ObjectValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public static bool IsValid<T>(T obj, bool throwException = false)
        {
            foreach (var p in obj.GetType().GetProperties())
            {
                if (p.GetCustomAttribute<RequiredAttribute>() != null)
                {
                    var value = p.GetValue(obj);
                    if (value == null)
                    {
                        if (throwException)
                            throw new ArgumentNullException(p.Name);

                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Validate<T>(T obj)
        {
            IsValid<T>(obj, true);
        }
    }
}
