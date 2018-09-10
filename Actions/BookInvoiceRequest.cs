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
using EconomicSDK.Objects;

namespace EconomicSDK.Actions
{
    /// <summary>
    /// Provides a book invoice request.
    /// </summary>
    /// <see cref="https://restdocs.e-conomic.com/#post-invoices-booked"/>
    public class BookInvoiceRequest
    {
        #region === member variables ===
        /// <summary>Invoice will be sent by EAN.</summary>
        public const string SENDBY_EAN = "ean";
        /// <summary>Invoice will be sent by mobilepay.</summary>
        public const string SENDBY_MOBILEPAY = "mobilepay";
        /// <summary>Invoice will not be sent.</summary>
        public const string SENDBY_NONE = "none";
        #endregion

        #region === public properties ===
        /// <summary>
        /// Book an invoice post a draftInvoice wrapped in an object as such.
        /// </summary>
        public DraftInvoice draftInvoice { get; set; }
        /// <summary>
        /// You can specify with which number the invoice is booked, by adding a “bookWithNumber” property.
        /// </summary>
        public int? bookWithNumber { get; set; }
        /// <summary>
        /// You can specify how to send using the static constants.
        /// </summary>
        /// <remarks>None, mobilePay or ean.</remarks>
        public string sendBy { get; set; }
        #endregion

        #region === static methods ===
        /// <summary>
        /// Creates a new book invoice request from an invoice.
        /// </summary>
        /// <param name="invoice">Invoice to create request from.</param>
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
        #endregion
    }
}
