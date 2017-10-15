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
    public abstract class ReadGenericManager<T> : GenericManager<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="baseUrl"></param>
        public ReadGenericManager(EconomicService client, string baseUrl) : base(client, baseUrl)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual GenericCollectionOf<T> List()
        {
            string url = _client.GetUrl(this.BaseUrl + "/");

            try
            {
                var response = JsonClient.Get<GenericCollectionOf<T>>(url, _client.GetHeaders());
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            if (id == 0)
                throw new ArgumentNullException();

            string url = _client.GetUrl(this.BaseUrl + "/" + id);

            try
            {
                var response = JsonClient.Get<T>(url, _client.GetHeaders());

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