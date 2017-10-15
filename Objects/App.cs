using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    public class App : BaseObject
    {
        public int appNumber { get; set; }
        public string appPublicToken { get; set; }
        public string appSecretToken { get; set; }
        public string created { get; set; }
        public string grantUrl { get; set; }
        public string name { get; set; }
    }
}
