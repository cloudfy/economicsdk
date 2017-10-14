using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerGroupManager
    {
        #region === constructor ===
        /// <summary></summary>
        private EconomicService _client;

        /// <summary></summary>
        /// <param name="client"></param>
        public CustomerGroupManager(EconomicService client)
        {
            _client = client;
        }
        #endregion

        #region === GET ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerGroupNumber"></param>
        /// <returns></returns>
        public CustomerGroup Get(int customerGroupNumber)
        {
            string url = _client.GetUrl("/customer-groups/" + customerGroupNumber);

            try
            {
                var response = JsonClient.Get<CustomerGroup>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region === POST ===
        /// <summary></summary>
        /// <param name="c"></param>
        /// <returns>EcnomicApi.Economic.Objects.CustomerGroup</returns>
        public CustomerGroup Create(CustomerGroup c)
        {
            string url = _client.GetUrl("/customer-groups/");

            // validate
            Validation.ObjectValidation.Validate<CustomerGroup>(c);

            try
            {
                var response = JsonClient.Post<CustomerGroup, CustomerGroup>(url, c, _client.GetHeaders());

                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === LIST ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="skippages"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public CollectionOfCustomerGroup List(int skippages = -1, int pagesize = 20)
        {
            if (pagesize > 1000)
                throw new ArgumentOutOfRangeException("Maximum pagesize is 1.000");

            string url = _client.GetUrl("/customer-groups/?pagesize=" + pagesize);

            try
            {
                var response = JsonClient.Get<CollectionOfCustomerGroup>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        public CollectionOfCustomer ListCustomers(int customerGroupNumber, int skippages = -1, int pagesize = 20)
        {
            if (customerGroupNumber == 0)
                throw new ArgumentNullException();

            if (pagesize > 1000)
                throw new ArgumentOutOfRangeException("Maximum pagesize is 1.000");

            string url = _client.GetUrl("/customer-groups/{0}/customers?pagesize={1}", customerGroupNumber , pagesize);

            try
            {
                var response = JsonClient.Get<CollectionOfCustomer>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
