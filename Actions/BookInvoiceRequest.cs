using EconomicSDK.Objects;

namespace EconomicSDK.Actions
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://restdocs.e-conomic.com/#post-invoices-booked"/>
    public class BookInvoiceRequest
    {
        public const string SENDBY_EAN = "ean";
        public const string SENDBY_MOBILEPAY = "mobilepay";
        public const string SENDBY_NONE = "none";

        /// <summary>
        /// Book an invoice post a draftInvoice wrapped in an object as such.
        /// </summary>
        public DraftInvoice draftInvoice { get; set; }
        /// <summary>
        /// You can specify with which number the invoice is booked, by adding a “bookWithNumber” property.
        /// </summary>
        public int? bookWithNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>None, mobilePay or ean.</remarks>
        public string sendBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static BookInvoiceRequest FromInvoice(Invoice invoice, string sendby = "", int? withNumber = null)
        {
            return new BookInvoiceRequest
            {
                draftInvoice = new DraftInvoice
                {
                    draftInvoiceNumber = invoice.draftInvoiceNumber,
                    self = invoice.self
                },
                sendBy = sendby,
                bookWithNumber = withNumber
            };
        }
    }
}
