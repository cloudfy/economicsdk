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
    public class JournalManager
    {
        /// <summary></summary>
        private EconomicService _client;

        /// <summary></summary>
        /// <param name="client"></param>
        public JournalManager(EconomicService client)
        {
            _client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skippages"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public CollectionOfJournal List(int skippages = -1, int pagesize = 20)
        {
            if (pagesize > 1000)
                throw new ArgumentOutOfRangeException("Maximum pagesize is 1.000");

            string url = _client.GetUrl("/journals-experimental/?pagesize=" + pagesize);

            try
            {
                var response = JsonClient.Get<CollectionOfJournal>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalNumber"></param>
        /// <param name="skippages"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public CollectionOfVouchers ListVouchers(int journalNumber, int skippages = -1, int pagesize = 20)
        {
            if (pagesize > 1000)
                throw new ArgumentOutOfRangeException("Maximum pagesize is 1.000");

            string url = _client.GetUrl("/journals-experimental/" + journalNumber  + "/vouchers?pagesize=" + pagesize);

            try
            {
                var response = JsonClient.Get<CollectionOfVouchers>(url, _client.GetHeaders());
                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalNumber"></param>
        /// <returns></returns>
        public Journal Get(int journalNumber)
        {
            string url = _client.GetUrl("/journals-experimental/" + journalNumber);

            try
            {
                var response = JsonClient.Get<Journal>(url, _client.GetHeaders());
                return response;
            }
            catch (JsonClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public Journal Create(Journal j)
        {
            string url = _client.GetUrl("/journals-experimental/");

            // validate
            Validation.ObjectValidation.Validate<Journal>(j);

            try
            {
                var response = JsonClient.Post<Journal, Journal>(url, j, _client.GetHeaders());

                return response;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalNumber"></param>
        /// <param name="newW"></param>
        public void CreateVouchers(int journalNumber, Vouchers newW)
        {
            string url = _client.GetUrl("/journals-experimental/{0}/vouchers", journalNumber);
            try
            {
                var response = JsonClient.Post<Vouchers, Vouchers>(url, newW, _client.GetHeaders());
            }
            catch (Newtonsoft.Json.JsonSerializationException ex)
            {
                Console.WriteLine("Response serialization issue");
                //throw ex;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="journalNumber"></param>
        /// <param name="voucherNumber"></param>
        public void DeleteVouchers(int journalNumber, int voucherNumber)
        {
            string url = _client.GetUrl("/journals-experimental/{0}/entries/{1}", journalNumber, voucherNumber);
            try
            {
                var response = JsonClient.Delete(url, _client.GetHeaders());
            }
            catch
            {
                throw;
            }
        }
    }
}
