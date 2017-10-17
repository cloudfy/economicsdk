using EconomicSDK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    public class PaymentTermManager : ReadWriteGenericManager<PaymentTerms>
    {
        public PaymentTermManager(EconomicService client, string baseUrl) : base(client, baseUrl)
        {

        }
    }
}
