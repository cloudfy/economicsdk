using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EconomicSDK.Validation
{
    /// <summary></summary>
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
