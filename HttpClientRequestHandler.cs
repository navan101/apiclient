using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RESTfulAPIConsume.RequestHandlers
{
    public class HttpClientRequestHandler : IRequestHandler

    {
        public string CallAPI(string api, string id, string invoicestatus, string signstatus)
        {
            try
            {
                var _url = "http://hoadon.epmt.com.vn:8118";

                api = string.Format(api, id, invoicestatus, signstatus);

                if (_url.StartsWith("https"))
                {
                    // truong hop giao thuc http khong can 2 dong nay
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 |
                    ServicePointManager.ServerCertificateValidationCallback += (senders, cert, chain, sslPolicyErrors) => true;
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // Nếu có token thì add Authorization
                    //if (!string.IsNullOrEmpty(token))
                    //{
                    //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    //}
                    HttpContent content = null;
                    //if (!string.IsNullOrEmpty(json))
                    //{
                    //    content = new StringContent(json, Encoding.UTF8, "application/json");
                    //}
                    HttpResponseMessage response = null;

                    response = client.PutAsync(api, content).Result;

                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    return responseContent;
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
