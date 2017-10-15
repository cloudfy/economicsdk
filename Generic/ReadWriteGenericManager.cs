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