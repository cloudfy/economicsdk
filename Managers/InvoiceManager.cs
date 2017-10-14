using EconomicSDK.Actions;
using EconomicSDK.Objects;
using System;

namespace EconomicSDK
{
    /// <summary></summary>
    public class InvoiceManager
    {
        #region === constructor ===
        /// <summary></summary>
        private EconomicService _client;

        /// <summary></summary>
        /// <param name="client"></param>
        public InvoiceManager(EconomicService client)
        {
            _client = client;
        }
        #endregion

        #region === GET ===
        /// <summary></summary>
        /// <param name="invoiceNumber"></param>
        /// <returns>EcnomicApi.Economic.Objects.Invoice</returns>
        public Invoice GetDraft(int invoiceNumber)
        {
            string url = _client.GetUrl("/invoices/drafts/" + invoiceNumber);

            try
            {
                var response = JsonClient.Get<Invoice>(url, _client.GetHeaders());
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
        /// <returns>EcnomicApi.Economic.Objects.Invoices</returns>
        public Invoices List()
        {
            string url = _client.GetUrl("/invoices/");

            try
            {
                var response = JsonClient.Get<Invoices>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary></summary>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfInvoice</returns>
        public CollectionOfInvoice ListDrafts()
        {
            string url = _client.GetUrl("/invoices/drafts");

            try
            {
                var response = JsonClient.Get<CollectionOfInvoice>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region === CREATE ===
        /// <summary>
        /// Create a new draft invoice. The method doesn’t also book it, but simply creates the draft.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Invoice Create(Invoice invoice)
        {
            string url = _client.GetUrl("/invoices/drafts");

            try
            {
                var response = JsonClient.Post<Invoice, Invoice>(url, invoice, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                msg = msg;
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region === book ===
        /// <summary>
        /// Books a draft invoice. If the operation is successful, this returns the full booked invoice.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public Invoice Book(Invoice invoice)
        {
            return Book(BookInvoiceRequest.FromInvoice(invoice));
        }

        /// <summary>
        /// Books a draft invoice. If the operation is successful, this returns the full booked invoice.
        /// </summary>
        /// <param name="bookInvoiceRequest"></param>
        public Invoice Book(BookInvoiceRequest bookInvoiceRequest)
        {
            string url = _client.GetUrl("/invoices/booked/");

            try
            {
                var response = JsonClient.Post<BookInvoiceRequest, Invoice>(url
                    , bookInvoiceRequest
                    , _client.GetHeaders());

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CollectionOfLayout ListLayouts()
        {
            string url = _client.GetUrl("/layouts/");

            try
            {
                var response = JsonClient.Get<CollectionOfLayout>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}