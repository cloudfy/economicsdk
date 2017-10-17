using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// 
    /// </summary>
    public class VatZoneManager : BaseManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        internal VatZoneManager(EconomicService client) : base(client)
        {
        }

        /// <summary></summary>
        /// <returns>EcnomicApi.Economic.Objects.CollectionOfProduct</returns>
        public CollectionOf<VatZone> List()
        {
            string url = this.Client.GetUrl("/vat-zones/");

            try
            {
                var response = JsonClient.Get<CollectionOf<VatZone>>(url, Client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
