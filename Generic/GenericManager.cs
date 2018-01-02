/*  
 *  This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>. 
*/

using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    public abstract class GenericManager<T>
    {
        /// <summary></summary>
        internal EconomicService _client;
        /// <summary></summary>
        private string _baseUrl;

        #region === constructor ===
        /// <summary></summary>
        internal GenericManager(EconomicService client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;
        }
        #endregion

        /// <summary></summary>
        internal string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }

        /// <summary></summary>
        internal RT Retrieve<RT>(string url)
        {
            try
            {
                var response = JsonClient.Get<RT>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw e;

                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
