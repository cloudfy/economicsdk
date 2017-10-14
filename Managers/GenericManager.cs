using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{

    public class GenericCollectionOf<T> : BaseObject
    {
        /// <summary></summary>
        public T[] collection { get; set; }
        /// <summary></summary>
        public Pagination pagination { get; set; }
        /// <summary></summary>
        public MetaData metaData { get; set; }
    }

    public class GenericManager<T>
    {
        #region === constructor ===
        /// <summary></summary>
        internal EconomicService _client;
        private string _baseUrl;

        internal GenericManager(EconomicService client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;
        }
        #endregion

        internal string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(T obj, int id)
        {
            string url = _client.GetUrl(_baseUrl + "/" + id);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Post(T obj)
        {
            string url = _client.GetUrl(_baseUrl + "/");

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

        public virtual GenericCollectionOf<T> List()
        {
            string url = _client.GetUrl(_baseUrl + "/");

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

        public virtual T Get(int id)
        {
            if (id == 0)
                throw new ArgumentNullException();

            string url = _client.GetUrl(_baseUrl + "/" + id);

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
