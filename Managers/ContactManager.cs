using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    public class ContactManager : BaseManager
    {
        #region === constructor ===
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        internal ContactManager(EconomicService client) : base(client)
        {

        }
        #endregion

        #region === GET ===
        /// <summary>
        /// Returns a given contact based on the contact & customer number.
        /// </summary>
        /// <param name="customerNumber">Customer number.</param>
        /// <param name="contactNumber">Contact number.</param>
        /// <returns></returns>
        public Contact Get(int customerNumber, int contactNumber)
        {
            string url = this.Client.GetUrl("/customers/" + customerNumber + "/contacts/" + contactNumber);

            try
            {
                var response = JsonClient.Get<Contact>(url, Client.GetHeaders());
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
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        public CollectionOfContact List(int customerNumber)
        {
            string url = this.Client.GetUrl("/customers/" + customerNumber + "/contacts");

            try
            {
                var response = JsonClient.Get<CollectionOfContact>(url, Client.GetHeaders());
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
