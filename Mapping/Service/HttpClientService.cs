using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Service
{
    public static class HttpClientService
    {
        private static readonly HttpClient HttpClient;

        static HttpClientService()
        {
            HttpClient = new HttpClient() { BaseAddress = new Uri("http://www.baidu.com") };
            HttpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            //帮HttpClient热身
            HttpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri("http://www.baidu.com" + "/")
            })
                .Result.EnsureSuccessStatusCode();
        }
        public static async Task<string> GetAsync(string url)
        {
            var response = await HttpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
