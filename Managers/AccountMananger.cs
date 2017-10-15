using System;
using System.Linq;
using System.Collections.Generic;
using EconomicSDK.Objects;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary>
    /// Accounts are the records in the general ledger where companies record the monetary transactions.
    /// </summary>
    public class AccountMananger : ReadGenericManager<Account>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        internal AccountMananger(EconomicService client) : base(client, "/accounts")
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id of account.</param>
        /// <returns>Returns a collecion of Accounting Years.</returns>
        public GenericCollectionOf<AccountingYear> AccountingYears(int id)
        {
            string url = _client.GetUrl(this.BaseUrl + "/{0}/accounting-years", id);

            return base.Retrieve<GenericCollectionOf<AccountingYear>>(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="accountingYear"></param>
        /// <returns></returns>
        public AccountingYear AccountingYear(int accountId, int accountingYear)
        {
            string url = _client.GetUrl(this.BaseUrl + "/{0}/accounting-years/{1}/", accountId, accountingYear);

            return base.Retrieve<AccountingYear>(url);
        }
    }

}