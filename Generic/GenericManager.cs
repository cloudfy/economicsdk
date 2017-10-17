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
        #region === constructor ===
        /// <summary></summary>
        internal EconomicService _client;
        private string _baseUrl;

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
