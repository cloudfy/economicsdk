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
    public class AppsManager : ReadGenericManager<App>
    {
        public AppsManager(EconomicService client, string baseUrl) : base(client, baseUrl)
        {

        }
    }
}
