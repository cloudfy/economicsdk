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
    public class VatAccountManager : ReadGenericManager<VatAccount>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="baseUrl"></param>
        public VatAccountManager(EconomicService client, string baseUrl) : base(client, "/vat-accounts/")
        {

        }
    }
}
