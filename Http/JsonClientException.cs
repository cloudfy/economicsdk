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
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EconomicSDK
{
    /// <summary>
    /// Represents errors that occur during Json requests.
    /// </summary>
    public class JsonClientException : Exception
    {
        #region === member variables ===
        /// <summary>Member variable for status code.</summary>
        private System.Net.HttpStatusCode _statusCode;
        #endregion

        #region === constructor ===
        /// <summary>
        /// Returns a new instace of the exception class.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="statusCode">Status code from the request.</param>
        public JsonClientException(string message, System.Net.HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }
        #endregion

        #region === public properties ===
        /// <summary>
        /// Gets the status code of the exception.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return _statusCode;
            }
        } 
        #endregion
    }
}