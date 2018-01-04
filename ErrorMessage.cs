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
    /// <summary></summary>
    public class ErrorMessage
    {
        /// <summary></summary>
        public string message { get; set; }
        /// <summary></summary>
        public string errorCode { get; set; }
        /// <summary></summary>
        public string developerHint { get; set; }
        /// <summary></summary>
        public Guid? logId { get; set; }
        /// <summary></summary>
        public int? httpStatusCode { get; set; }
        /// <summary></summary>
        public Errors errors { get; set; }
        /// <summary></summary>
        public DateTime? logTime { get; set; }
        /// <summary></summary>
        public string schemaPath { get; set; }
        /// <summary></summary>
        public int? errorCount { get; set; }
    }
    /// <summary></summary>
    public class Errors
    {
        public ErrorLines lines { get; set; }
    }
    /// <summary></summary>
    public class Error
    {
        /// <summary></summary>
        public string errorMessage { get; set; }
        /// <summary></summary>
        public string errorCode { get; set; }
        /// <summary></summary>
        public string inputValue { get; set; }
        /// <summary></summary>
        public string developerHint { get; set; }
    }
    /// <summary></summary>
    public class ProductError
    {
        /// <summary></summary>
        public List<Error> errors { get; set; }
    }
    /// <summary></summary>
    public class ErrorItem
    {
        /// <summary></summary>
        public int? arrayIndex { get; set; }
        /// <summary></summary>
        public ProductError product { get; set; }
    }
    /// <summary></summary>
    public class ErrorLines
    {
        /// <summary></summary>
        public List<ErrorItem> items { get; set; }
    }

}
