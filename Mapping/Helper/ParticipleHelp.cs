using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using System.Net.Http;
using System.Web.Helpers;
using Mapping.Model;
using Mapping.Service;

namespace Mapping.Helper
{
    public static class ParticipleHelp
    {
        private const string Key = "c14436C9w1T6F5z150G92gKYdP9YpHgtdE2LaN0I";//讯飞key

        public static async Task<string[]> PostParticiple(string name)
        {
            //为保障系统稳定，语言云API的使用频率默认限制为每个IP 200次/秒。
            Thread.Sleep(7);
            var words = new List<string>();
            try
            {
                const string url = "http://ltpapi.voicecloud.cn/analysis/";
                var parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("api_key", Key),
                    new KeyValuePair<string, string>("text", name),
                    new KeyValuePair<string, string>("pattern", "all"),
                    new KeyValuePair<string, string>("format", "json")
                };
                var result = await HttpClientService.PostAsync(url,parameters);


                var local = Json.Decode(result)[0][0];
                if (local.Length != 0)
                {
                    foreach (var item in local)
                    {
                        words.Add(item.cont);
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return words.ToArray();
        }
        public static async Task<string[]> GetParticiple(string name)
        {
            //为保障系统稳定，语言云API的使用频率默认限制为每个IP 200次/秒。
            Thread.Sleep(7);
            var words = new List<string>();
            try
            {
                var url = $"http://ltpapi.voicecloud.cn/analysis/?api_key={Key}&text={name}&pattern=all&format=json";
                var result = await GetResponseStringAsync(url);


                var local = Json.Decode(result)[0][0];
                if (local.Length != 0)
                {
                    foreach (var item in local)
                    {
                        words.Add(item.cont);
                    }
                }
            }
            catch (Exception)
            {

            }
            return words.ToArray();
        }
        private static async Task<string> GetResponseStringAsync(string url)
        {
            try
            {
                return await HttpClientService.GetAsync(url);
               
            }
            catch (Exception ex)
            {
                // ignored
            }
            return null;//error
        }
    }
}
