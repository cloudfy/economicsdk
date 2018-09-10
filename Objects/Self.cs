using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK.Objects
{
    public class Self : BaseObject
    {
        public int agreementNumber { get; set; }
        public AgreementType agreementType { get; set; }
        public string userName { get; set; }
        public string signupDate { get; set; }
        public User user { get; set; }
        public Company company { get; set; }
        public BankInformation bankInformation { get; set; }
        public Application application { get; set; }
        public Settings settings { get; set; }
        public string companyAffiliation { get; set; }
        public bool canSendMobilePay { get; set; }
        public bool canSendElectronicInvoice { get; set; }
        public List<Module> modules { get; set; }
    }

    public class AgreementType
    {
        public int agreementTypeNumber { get; set; }
        public string name { get; set; }
    }

    public class Language
    {
        public int languageNumber { get; set; }
        public string name { get; set; }
        public string culture { get; set; }
        public string self { get; set; }
    }

    public class User
    {
        public string loginId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Language language { get; set; }
        public int agreementNumber { get; set; }
    }

    public class Company
    {
        public string addressLine1 { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string attention { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public string companyIdentificationNumber { get; set; }
        public string vatNumber { get; set; }
    }

    public class BankInformation
    {
        public string bankName { get; set; }
        public string swiftCode { get; set; }
        public string ibanNumber { get; set; }
        public string bankSortCode { get; set; }
        public string bankAccountNumber { get; set; }
        public string pbsCustomerGroupNumber { get; set; }
    }

    public class RequiredRole
    {
        public int roleNumber { get; set; }
        public string name { get; set; }
    }

    public class Application
    {
        public int appNumber { get; set; }
        public string name { get; set; }
        public string appPublicToken { get; set; }
        public string created { get; set; }
        public List<RequiredRole> requiredRoles { get; set; }
        public string self { get; set; }
    }

    public class Settings
    {
        public string baseCurrency { get; set; }
    }

    public class Module
    {
        public int moduleNumber { get; set; }
        public string name { get; set; }
        public string self { get; set; }
    }
}
