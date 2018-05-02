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
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace EconomicSDK
{
    /// <summary>Provides access to the e-conomic API and methods.</summary>
    /// <remarks></remarks>
    public sealed class EconomicService
    {
        #region === member variables ===
        /// <summary></summary>
        private const string apiUrl = "https://restapi.e-conomic.com";

        /// <summary></summary>
        private string _grantToken;
        /// <summary></summary>
        private string _secretToken;

        /// <summary></summary>
        private AccountMananger _acocuntsManager;
        /// <summary></summary>
        private CustomerManager _customerManager;
        /// <summary></summary>
        private InvoiceManager _invoiceManager;
        /// <summary></summary>
        private ProductManager _productManager;
        /// <summary></summary>
        private PaymentTermManager _paymentTerms;
        /// <summary></summary>
        private JournalManager _journalManager;
        /// <summary></summary>
        private VatZoneManager _vatZones;
        /// <summary></summary>
        private CustomerGroupManager _customerGroupManager;
        /// <summary></summary>
        private AppsManager _appsManager;
        /// <summary></summary>
        private VatAccountManager _vatAccounts;
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

        #region === static methods ===
        /// <summary></summary>
        /// <param name="d"></param>
        /// <returns>string</returns>
        public static string GetDate(DateTime d)
        {
            return d.ToString("yyyy-MM-dd");
        }
        #endregion

        #region === manager prooperties ===
        /// <summary></summary>
        public ContactManager Contacts
        {
            get
            {
                return new ContactManager(this);
            }
        }
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
        public JournalManager Journals
        {
            get
            {
                if (_journalManager == null)
                    _journalManager = new JournalManager(this);

                return _journalManager;
            }
        }
        /// <summary></summary>
        public AppsManager Apps
        {
            get
            {
                if (_appsManager == null)
                    _appsManager = new AppsManager(this, "/apps");

                return _appsManager;
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

        /// <summary>
        /// 
        /// </summary>
        public PaymentTermManager PaymentTerms
        {
            get
            {
                if (_paymentTerms == null)
                    _paymentTerms = new PaymentTermManager(this, "/payment-terms");

                return _paymentTerms;
            }
        }

        public VatAccountManager VatAccounts
        {
            get
            {
                if (_vatAccounts == null)
                    _vatAccounts = new VatAccountManager(this, "/vat-accounts/");

                return _vatAccounts;
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
