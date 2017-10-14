using System;
using System.Linq;
using System.Collections.Generic;
using EconomicSDK.Objects;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{

    public class AccountMananger : GenericManager<Account>
    {
        internal AccountMananger(EconomicClient client) : base(client, "/accounts")
        {
        }
        public override bool Delete(Account obj, int id)
        {
            throw new NotImplementedException();
        }
        public override Account Post(Account obj)
        {
            throw new NotImplementedException();
        }
        public GenericCollectionOf<AccountingYear> AccountingYears(int id)
        {
            string url = _client.GetUrl(this.BaseUrl + "/{0}/accounting-years", id);

            try
            {
                var response = JsonClient.Get<GenericCollectionOf<AccountingYear>>(url, _client.GetHeaders());

                return response;
            }
            catch (JsonClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw e;

                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}