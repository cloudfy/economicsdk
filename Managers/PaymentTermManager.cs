using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    public class PaymentTermManager : ReadWriteGenericManager<PaymentTerms>
    {
        /// <summary></summary>
        public PaymentTermManager(EconomicService client, string baseUrl) : base(client, baseUrl)
        {

        }
    }
}
