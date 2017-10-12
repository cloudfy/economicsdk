using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK {
    /// <summary></summary>
    public class CustomerManager
    {
        #region === constructor ===
        /// <summary></summary>
        private EconomicClient _client;

        /// <summary></summary>
        /// <param name="client"></param>
        public CustomerManager(EconomicClient client)
        {
            _client = client;
        }
        #endregion

        #region === LIST ===
        /// <summary></summary>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfCustomer</returns>
        public CollectionOfCustomer List()
        {
            string url = _client.GetUrl("/customers/");

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

        #region === GET ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public Customer Get(int customerNumber)
        {
            string url = _client.GetUrl("/customers/" + customerNumber);

            try
            {
                var response = JsonClient.Get<Customer>(url, _client.GetHeaders());
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

        #region === FIND ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public CollectionOfCustomer Find(string query)
        {
            string url = _client.GetUrl("/customers/?filter=" + query);

            try
            {
                var response = JsonClient.Get<CollectionOfCustomer>(url, _client.GetHeaders());
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
        /// <param name="name"></param>
        /// <param name="currencyCode"></param>
        /// <returns>EcnomicApi.Economic.Objects.Customer</returns>
        [Obsolete]
        public Customer Create(string name, string currencyCode)
        {
            Customer newCustomer = new Customer { currency = currencyCode, name = name };
            return Create(newCustomer);
        }

        /// <summary></summary>
        /// <param name="c"></param>
        /// <returns>EcnomicApi.Economic.Objects.Customer</returns>
        public Customer Create(Customer c)
        {
            string url = _client.GetUrl("/customers/");

            // validate
            Validation.ObjectValidation.Validate<Customer>(c);

            try
            {
                var response = JsonClient.Post<Customer, Customer>(url, c, _client.GetHeaders());

                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === Temaplte === 
        public Invoice TemplateInvoice(Customer customer)
        {
            string url = _client.GetUrl("/customers/" + customer.customerNumber + "/templates/invoice");

            try
            {
                var response = JsonClient.Get<Invoice>(url, _client.GetHeaders());
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

        public InvoiceLine TemplateInvoiceLine(Customer customer)
        {
            string url = _client.GetUrl("/customers/" + customer.customerNumber + "/templates/invoiceline");

            try
            {
                var response = JsonClient.Get<InvoiceLine>(url, _client.GetHeaders());
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
    }
}
