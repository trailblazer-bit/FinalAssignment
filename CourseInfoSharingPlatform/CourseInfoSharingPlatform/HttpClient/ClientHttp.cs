using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class ClientHttp
    {
        private static readonly HttpClient client = new HttpClient();
        public static HttpClient GetInstance()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public static string GET(string url, Dictionary<string, string> parameters)
        {
            if (parameters.Count != 0) //有参数的情况下，拼接url
            {
                url = url + "?";
                foreach (var item in parameters)
                {
                    url = url + item.Key + "=" + item.Value + "&";
                }
                url = url.Substring(0, url.Length - 1);
            }
            HttpResponseMessage response = GetInstance().GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            return null;
        }
        //参数分别为请求路径和请求体的json对象
        public static async Task<bool> POST(string url,string parameterJson)
        {
            HttpContent content = new StringContent(parameterJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await GetInstance().PostAsync(url, content);
            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

    }
}
