using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    /// <summary>
    /// A schema for retrieving a collection of API App.
    /// </summary>
    public class App : BaseObject
    {
        /// <summary>A reference number for the API App.</summary>
        public int appNumber { get; set; }
        /// <summary>The appPublicToken is used for issuing grants.</summary>
        public string appPublicToken { get; set; }
        /// <summary>The appSecretToken is used for accessing the API along side the agreementGrantToken. This is only displayed right after creating a new app.</summary>
        public string appSecretToken { get; set; }
        /// <summary></summary>
        public string created { get; set; }
        /// <summary>Link used for issuing grants.</summary>
        public string grantUrl { get; set; }
        /// <summary>API App name, which is displayed to people before they grant access.</summary>
        public string name { get; set; }
        /// <summary>Root URL used for issuing grants. Redirects after the grant are restricted to this Root URL.</summary>
        public string rootUrl { get; set; }
        /// <summary>Roles required to issue a grant.</summary>
        public Role[] requiredRoles { get; set; }
    }
}
