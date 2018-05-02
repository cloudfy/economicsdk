using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    public class ProductManager : BaseManager
    {
        #region === constructor ===
        /// <summary></summary>
        /// <param name="client"></param>
        internal ProductManager(EconomicService client) : base(client)
        {
        }
        #endregion

        #region === GET ===
        /// <summary></summary>
        /// <param name="productNumber"></param>
        /// <returns>EcnomicApi.Economic.Objects.Product</returns>
        public Product Get(string productNumber)
        {
            string url = Client.GetUrl("/products/" + productNumber);

            try
            {
                var response = JsonClient.Get<Product>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary></summary>
        /// <param name="productNumber"></param>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfProductPricing</returns>
        public CollectionOf<ProductPricing> GetCurrencySpecificSalesPrices(string productNumber)
        {
            if (string.IsNullOrEmpty(productNumber))
                throw new ArgumentNullException("ProductNumber");

            string url = Client.GetUrl("/products/{0}/pricing/currency-specific-sales-prices", productNumber);

            try
            {
                var response = JsonClient.Get<CollectionOf<ProductPricing>>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary></summary>
        /// <param name="productNumber"></param>
        /// <param name="currencyCode"></param>
        /// <returns>EcnomicApi.Economic.Objects.ProductPricing</returns>
        public ProductPricing GetCurrencySpecificSalesPrice(string productNumber, string currencyCode)
        {
            if (string.IsNullOrEmpty(currencyCode))
                throw new ArgumentNullException("CurrencyCode");
            if (string.IsNullOrEmpty(productNumber))
                throw new ArgumentNullException("ProductNumber");

            string url = Client.GetUrl("/products/{0}/pricing/currency-specific-sales-prices/{1}", productNumber, currencyCode);

            try
            {
                var response = JsonClient.Get<ProductPricing>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === FIND ===
        /// <summary></summary>
        /// <param name="filter"></param>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfProduct</returns>
        public CollectionOfProduct Find(FilterPart filter)
        {
            return Find(new FilterPart[] { filter }, FilterEnum.and);
        }
        /// <summary></summary>
        /// <param name="filters"></param>
        /// <param name="filter"></param>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfProduct</returns>
        public CollectionOfProduct Find(FilterPart[] filters, FilterEnum filter)
        {
            if (filters == null)
                throw new ArgumentNullException();

            string query = Helpers.CollectFilters(filters, filter);

            string url = Client.GetUrl("/products/?filter=" + query);
            try
            {
                var response = JsonClient.Get<CollectionOfProduct>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === LIST ===
        /// <summary></summary>
        /// <param name="options"></param>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfProduct</returns>
        public CollectionOfProduct List(ViewOptions options = null)
        {
            string url = this.Client.GetUrl("/products/");

            if (options != null)
                options.AppendTo(ref url);

            try
            {
                var response = JsonClient.Get<CollectionOfProduct>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === POST ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            string url = Client.GetUrl("/products/");

            try
            {
                var response = JsonClient.Post<Product, Product>(url, product, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }

    public abstract class BaseManager {
        private EconomicService _client;
        internal BaseManager(EconomicService client)
        {
            _client = client;
        }

        internal EconomicService Client
        {
            get
            {
                return _client;
            }
        }
    }
}
