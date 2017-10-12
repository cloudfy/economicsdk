using EconomicSDK.Objects;

namespace EconomicSDK.Actions
{
    /// <summary>
    /// 
    /// </summary>
    public class BookInvoiceRequest
    {
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
        public static BookInvoiceRequest FromInvoice(Invoice invoice)
        {
            return new BookInvoiceRequest
            {
                draftInvoice = new DraftInvoice
                {
                    draftInvoiceNumber = invoice.draftInvoiceNumber,
                    self = invoice.self
                }
            };
        }
    }
}
