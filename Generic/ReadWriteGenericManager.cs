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
using EconomicSDK.Objects;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReadWriteGenericManager<T> : ReadGenericManager<T>
    {
        #region === constructor ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="baseUrl"></param>
        internal ReadWriteGenericManager(EconomicService client, string baseUrl) : base(client, baseUrl)
        {

        }
        #endregion

        #region === DELETE ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(T obj, int id)
        {
            string url = _client.GetUrl(this.BaseUrl + "/" + id);

            try
            {
                var response = JsonClient.Delete(url, _client.GetHeaders());
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
        #endregion

        #region === CREATE ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Post(T obj)
        {
            string url = _client.GetUrl(this.BaseUrl + "/");

            try
            {
                var response = JsonClient.Post<T, T>(url, obj, _client.GetHeaders());
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
        #endregion
    }

}