using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EconomicSDK
{
    /// <summary>
    /// Provides HTTP serialization and access to REST based APIs.
    /// </summary>
    internal static class JsonClient
    {
        #region === static methods ===
        /// <summary>Converts a string into a base64 string.</summary>
        /// <param name="input">String to convert.</param>
        /// <returns>string</returns>
        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        } 
        #endregion

        #region === PUT ===
        /// <summary>Provides a serialized PUT method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="body">Body of the request.</param>
        /// <param name="headers">HTTP headers of the request.</param>
        /// <returns>string</returns>
        public static string Put(string url, string body, StringDictionary headers)
        {
            return ExecuteRequest("PUT", url, body, headers);
        }

        /// <summary>Provides a serialized PUT method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="requestBody">Body of the request.</param>
        /// <param name="headers">HTTP headers of the request.</param>
        /// <returns>TResponse</returns>
        public static TResponse Put<TResponse>(string url, string requestBody, StringDictionary headers)
        {
            string responseBody = ExecuteRequest("PUT", url, requestBody, headers);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody, GetJsonSerializerSettings());
        }

        /// <summary>Provides a serialized PUT method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="request">Request of the method.</param>
        /// <param name="headers">HTTP headers of the request.</param>
        /// <returns>TResponse</returns>
        public static TResponse Put<TRequest, TResponse>(string url, TRequest request, StringDictionary headers)
        {
            return ExecuteRequest<TRequest, TResponse>("PUT", url, request, headers);
        }
        #endregion

        #region === POST ===
        /// <summary>Provides a serialized POST method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="body">Body of the request.</param>
        /// <param name="headers">HTTP headers of the request.</param>
        /// <returns>string</returns>
        public static string Post(string url, string body, StringDictionary headers)
        {
            return ExecuteRequest("POST", url, body, headers);
        }

        /// <summary>Provides a serialized POST method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="requestBody">Body of the request.</param>
        /// <param name="headers">HTTP headers of the request.</param>
        /// <returns>TResponse</returns>
        public static TResponse Post<TResponse>(string url, string requestBody, StringDictionary headers)
        {
            string responseBody = ExecuteRequest("POST", url, requestBody, headers);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody, GetJsonSerializerSettings());
        }

        /// <summary>Provides a serialized POST method for an API.</summary>
        /// <param name="url">Url of the request.</param>
        /// <param name="request">Body of the request.</param>
        /// <param name="headers">HTTP headers of the request.</param>
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

        #region === REQUEST ===
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
                GetJsonSerializerSettings()
            );

            string responseBody = ExecuteRequest(method, url, requestBody, headers);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(responseBody, GetJsonSerializerSettings());
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
                // write body as UTF-8 encoding
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(body);

                // set content length
                request.ContentLength = bytes.Length;

                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(bytes, 0, bytes.Length);
            }

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK | response.StatusCode == HttpStatusCode.Created | response.StatusCode == HttpStatusCode.NoContent)
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
        #endregion

        #region === statics ===
        /// <summary>
        /// Reads the response stream.
        /// </summary>
        /// <param name="s">Stream to read.</param>
        /// <returns></returns>
        private static string ReadResponse(Stream s)
        {
            using (var reader = new StreamReader(s))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Returns common serialization settings.
        /// </summary>
        /// <returns></returns>
        private static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }
        #endregion
    }
}
