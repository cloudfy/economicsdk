using EconomicSDK.Actions;
using EconomicSDK.Objects;
using Newtonsoft.Json;
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
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Delete a draft invoice based in draft invoice number.
        /// </summary>
        /// <param name="invoiceNumber">Draft invoice number.</param>
        /// <returns>True when deleted successfully.</returns>
        public bool DeleteDraft(int invoiceNumber)
        {
            string url = _client.GetUrl("/invoices/drafts/" + invoiceNumber);

            try
            {
                var response = JsonClient.Delete(url, _client.GetHeaders());
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Delete a draft invoice based in draft invoice object.
        /// </summary>
        /// <param name="invoice">Draft invoice object.</param>
        /// <returns>True when deleted successfully.</returns>
        public bool DeleteDraft(Invoice invoice)
        {
            return DeleteDraft(invoice.draftInvoiceNumber);
        }

        /// <summary>
        /// Downloads a booked Pdf.
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool DownloadBookedPdf(int invoiceNumber, string fileName)
        {
            if (invoiceNumber <= 0)
                throw new ArgumentOutOfRangeException("invoiceNumber");
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            string url = _client.GetUrl("/invoices/booked/" + invoiceNumber + "/pdf");

            try
            {
                // use a web client
                System.Net.WebClient wc = new System.Net.WebClient();
                var headers = _client.GetHeaders();
                foreach (string h in headers.Keys)
                    wc.Headers.Add(h, headers[h]);
                // binary download
                wc.DownloadFile(url, fileName);
                return true;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Downloads a draft Pdf.
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool DownloadDraftPdf(int invoiceNumber, string fileName)
        {
            if (invoiceNumber <= 0)
                throw new ArgumentOutOfRangeException("invoiceNumber");
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            string url = _client.GetUrl("/invoices/drafts/" + invoiceNumber + "/pdf");

            try
            {
                // use a web client
                System.Net.WebClient wc = new System.Net.WebClient();
                var headers = _client.GetHeaders();
                foreach (string h in headers.Keys)
                    wc.Headers.Add(h, headers[h]);
                // binary download
                wc.DownloadFile(url, fileName);
                return true;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        public Invoice GetBooked(int invoiceNumber)
        {
            string url = _client.GetUrl("/invoices/booked/" + invoiceNumber);

            try
            {
                var response = JsonClient.Get<Invoice>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
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
        /// <param name="options"></param>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfInvoice</returns>
        public CollectionOfInvoice ListDrafts(ViewOptions options = null)
        {
            string url = _client.GetUrl("/invoices/drafts");

            if (options != null)
                options.AppendTo(ref url);

            try
            {
                var response = JsonClient.Get<CollectionOfInvoice>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public CollectionOfInvoice ListBooked(ViewOptions options = null)
        {
            string url = _client.GetUrl("/invoices/booked?sort=-bookedInvoiceNumber");

            if (options != null)
                options.AppendTo(ref url);

            try
            {
                var response = JsonClient.Get<CollectionOfInvoice>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="draftInvoice"></param>
        /// <param name="invoiceNumeric"></param>
        /// <param name="sendBy"></param>
        public Invoice BookWithNumber(Invoice draftInvoice, int invoiceNumeric, string sendBy)
        {
            return BookWithNumber(BookInvoiceRequest.FromInvoice(draftInvoice, sendBy, invoiceNumeric));
        }
        #endregion

        #region === CREATE ===
        /// <summary>
        /// Create a new draft invoice. The method doesn’t also book it, but simply creates the draft.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        /// <exception cref="EconomicException"></exception>
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
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
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
        /// 
        /// </summary>
        /// <param name="bookInvoiceRequest"></param>
        /// <returns></returns>
        /// <exception cref="EconomicException"></exception>
        public Invoice BookWithNumber(BookInvoiceRequest bookInvoiceRequest)
        {
            if (!bookInvoiceRequest.bookWithNumber.HasValue)
                throw new ArgumentNullException("Book with number method, MUST have a book with number");

            string url = _client.GetUrl("/invoices/booked/" + bookInvoiceRequest.bookWithNumber);

            try
            {
                var response = JsonClient.Put<BookInvoiceRequest, Invoice>(url
                    , bookInvoiceRequest
                    , _client.GetHeaders());

                return response;
            }
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Books a draft invoice. If the operation is successful, this returns the full booked invoice.
        /// </summary>
        /// <param name="bookInvoiceRequest"></param>
        /// <exception cref="EconomicException"></exception>
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
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
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
            catch (JsonClientException e)
            {
                var errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(e.Message);
                throw new EconomicException(errorMessage, e);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}