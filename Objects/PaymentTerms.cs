using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EconomicSDK.Objects
{
    /// <summary></summary>
    public class PaymentTerms : BaseObject
    {
        /// <summary></summary>
        public object creditCardCompany { get; set; }
        /// <summary></summary>
        public int paymentTermsNumber { get; set; }
        /// <summary></summary>
        public int daysOfCredit { get; set; }
        /// <summary></summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public paymentTermsTypeEnum paymentTermsType { get; private set; }
        /// <summary></summary>
        public string name { get; set; }
        /// <summary></summary>
        public string description { get; set; }
        /// <summary></summary>
        public dynamic contraAccountForPrepaidAmount { get; set; }
        /// <summary></summary>
        public int percentageForRemainderAmount { get; set; }
        /// <summary></summary>
        public int percentageForPrepaidAmount { get; set; }
    }

    /// <summary></summary>
    public enum paymentTermsTypeEnum
    {
        /// <summary></summary>
        net,
        /// <summary></summary>
        invoiceMonth,
        /// <summary></summary>
        paidInCash,
        /// <summary></summary>
        prepaid,
        /// <summary></summary>
        dueDate,
        /// <summary></summary>
        factoring,
        /// <summary></summary>
        invoiceWeekStartingSunday,
        /// <summary></summary>
        invoiceWeekStartingMonday,
        /// <summary></summary>
        creditcard,
        /// <summary></summary>
        avtaleGiro
    }
}