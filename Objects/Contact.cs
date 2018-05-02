using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    public class Contact : BaseObject
    {
        public Customer Customer { get; set; }
        public int customerContactNumber { get; set; }
        public bool deleted { get; set; }
        public string eInvoiceId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string phone { get; set; }
    }
}
