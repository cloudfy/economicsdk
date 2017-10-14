using System;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace EconomicSDK
{
    /// <summary>Provides access to the e-conomic API and methods.</summary>
    public sealed class EconomicService
    {
        #region === member variables ===
        /// <summary></summary>
        private const string apiUrl = "https://restapi.e-conomic.com";

        /// <summary></summary>
        private AccountMananger _acocuntsManager;
        /// <summary></summary>
        private CustomerManager _customerManager;
        /// <summary></summary>
        private InvoiceManager _invoiceManager;
        /// <summary></summary>
        private ProductManager _productManager;
        /// <summary></summary>
        private VatZoneManager _vatZones;
        /// <summary></summary>
        private CustomerGroupManager _customerGroupManager;
        /// <summary></summary>
        private string _grantToken;
        /// <summary></summary>
        private string _secretToken;        
        #endregion

        #region === constructor ===
        /// <summary>
        /// Initializes a new instance of the Economic service class.
        /// </summary>
        /// <param name="grantToken">Grand token of the E-conomic client instance after adding the app.</param>
        /// <param name="secretToken">Secret token provided upon registrering the application.</param>
        public EconomicService(string grantToken, string secretToken)
        {
            if (string.IsNullOrEmpty(grantToken))
                throw new ArgumentNullException("GrantToken");
            if (string.IsNullOrEmpty(secretToken))
                throw new ArgumentNullException("SecretToken");

            _grantToken = grantToken;
            _secretToken = secretToken;
        }
        #endregion

        /// <summary></summary>
        /// <param name="d"></param>
        /// <returns>string</returns>
        public static string GetDate(DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }

        #region === manager prooperties ===
        /// <summary></summary>
        public ProductManager Products
        {
            get
            {
                if (_productManager == null)
                    _productManager = new ProductManager(this);

                return _productManager;
            }
        }
        /// <summary></summary>
        public AccountMananger Accounts
        {
            get
            {
                if (_acocuntsManager == null)
                    _acocuntsManager = new AccountMananger(this);

                return _acocuntsManager;
            }
        }
        /// <summary></summary>
        public AppsManager Apps
        {
            get
            {
                return new AppsManager();
            }
        }

        /// <summary></summary>
        public CustomerManager Customers
        {
            get
            {
                if (_customerManager == null)
                    _customerManager = new CustomerManager(this);

                return _customerManager;
            }
        }

        /// <summary></summary>
        public CustomerGroupManager CustomerGroups
        {
            get
            {
                if (_customerGroupManager == null)
                    _customerGroupManager = new CustomerGroupManager(this);

                return _customerGroupManager;
            }
        }

        /// <summary></summary>
        public InvoiceManager Invoices
        {
            get
            {
                if (_invoiceManager == null)
                    _invoiceManager = new InvoiceManager(this);

                return _invoiceManager;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public VatZoneManager VatZones
        {
            get
            {
                if (_vatZones == null)
                    _vatZones = new VatZoneManager(this);

                return _vatZones;
            }
        }
        #endregion

        #region === internals ===
        /// <summary></summary>
        /// <param name="path"></param>
        /// <returns>string</returns>
        internal string GetUrl(string path)
        {
            return string.Format("{0}{1}", apiUrl, path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal string GetUrl(string path, params object[] args)
        {
            var pathUrl = string.Format(path, args);
            return string.Format("{0}{1}", apiUrl, pathUrl);
        }

        /// <summary></summary>
        /// <returns>System.Collections.Specialized.StringDictionary</returns>
        internal StringDictionary GetHeaders()
        {
            StringDictionary headers = new StringDictionary();
            headers.Add("X-AppSecretToken", _secretToken);
            headers.Add("X-AgreementGrantToken", _grantToken);
            headers.Add("Content-Type", "application/json; charset=UTF-8");
            headers.Add("Accept", "application/json; charset=UTF-8");

            return headers;
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        internal Exception CreateException(JsonClientException e)
        {
            var eo = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorMessage>(e.Message);

            return new EconomicException(eo, e);
        }
        #endregion
    }

}
