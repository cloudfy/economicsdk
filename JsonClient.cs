using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EconomicSDK
{
    /// <summary></summary>
    static class JsonClient
    {
        /// <summary></summary>
        /// <param name="input"></param>
        /// <returns>string</returns>
        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
        }

        #region === PUT ===
        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns>string</returns>
        public static string Put(string url, string body, StringDictionary headers)
        {
            return ExecuteRequest("PUT", url, body, headers);
        }

        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="requestBody"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        public static TResponse Put<TResponse>(string url, string requestBody, StringDictionary headers)
        {
            string responseBody = ExecuteRequest("PUT", url, requestBody, headers);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        public static TResponse Put<TRequest, TResponse>(string url, TRequest request, StringDictionary headers)
        {
            return ExecuteRequest<TRequest, TResponse>("PUT", url, request, headers);
        }
        #endregion

        #region === POST ===
        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns>string</returns>
        public static string Post(string url, string body, StringDictionary headers)
        {
            return ExecuteRequest("POST", url, body, headers);
        }

        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="requestBody"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        public static TResponse Post<TResponse>(string url, string requestBody, StringDictionary headers)
        {
            string responseBody = ExecuteRequest("POST", url, requestBody, headers);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        public static TResponse Post<TRequest, TResponse>(string url, TRequest request, StringDictionary headers)
        {
            return ExecuteRequest<TRequest, TResponse>("POST", url, request, headers);
        }
        #endregion

        #region === GET ===
        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        public static TResponse Get<TResponse>(string url, StringDictionary headers)
        {
            return ExecuteRequest<Object, TResponse>("GET", url, null, headers);
        }
        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns>string</returns>
        public static string Get(string url, StringDictionary headers)
        {
            return ExecuteRequest("GET", url, null, headers);
        }
        #endregion

        #region === DEL ===
        /// <summary></summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns>bool</returns>
        public static bool Delete(string url, StringDictionary headers)
        {
            var response = ExecuteRequest("DELETE", url, null, headers);
            return true;
        }
        #endregion

        /// <summary></summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        /// <returns>TResponse</returns>
        private static TResponse ExecuteRequest<TRequest, TResponse>(string method, string url, TRequest request, StringDictionary headers)
        {
            string requestBody = Newtonsoft.Json.JsonConvert.SerializeObject(request,
                Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            string responseBody = ExecuteRequest(method, url, requestBody, headers);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody);
        }

        /// <summary></summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="headers"></param>
        /// <returns>string</returns>
        private static string ExecuteRequest(string method, string url, string body, StringDictionary headers)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method.ToUpper();
            request.AllowAutoRedirect = true;
            request.Timeout = 50000;
            //System.Net.ServicePointManager.Expect100Continue = false;

            foreach (string key in headers.Keys)
            {
                if (key.ToLower() == "content-type")
                    request.ContentType = headers[key];
                else if (key.ToLower() == "accept")
                    request.Accept = headers[key];
                else
                    request.Headers.Add(key, headers[key]);
            }

            if (request.Method == "POST" | request.Method == "PUT")
            {
                // see http://csharp.tips/tip/article/7-Bug-Fix---Cannot-close-stream-until-all-bytes-are-written
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(body);

                request.ContentLength = bytes.Length; // body.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    //using (BinaryWriter binary = new BinaryWriter(requestStream, Encoding.ASCII))
                    //{
                    //    var textBytes = Encoding.UTF8.GetBytes(body);
                    //    //var asciiBytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, textBytes);
                    //    binary.Write(textBytes);
                    //}
                    //using (StreamWriter requestStreamWriter = new StreamWriter(requestStream, Encoding.UTF8))
                    //{
                    //    writeStream.Write(bytes, 0, bytes.Length);
                    //    //requestStreamWriter.Write(body);
                    //}
                }
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK | response.StatusCode == HttpStatusCode.Created)
                    {
                        return ReadResponse(response.GetResponseStream());
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (WebException e)
            {
                var text = ReadResponse(e.Response.GetResponseStream());
                throw new JsonClientException(text, (e.Response as HttpWebResponse).StatusCode);
                //throw new ApplicationException(string.Format("Bad response {0}. {1}", e.Status, text), e);
            }
            catch (Exception e)
            {
                e = e;
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string ReadResponse(Stream s)
        {
            using (var reader = new StreamReader(s))
            {
                return reader.ReadToEnd();
            }
        }
    }

    /// <summary></summary>
    public class JsonClientException : Exception
    {
        private System.Net.HttpStatusCode _statusCode;

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        public JsonClientException(string message, System.Net.HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                return _statusCode;
            }
        }
    }
}
