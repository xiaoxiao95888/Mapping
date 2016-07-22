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

namespace Mapping.Helper
{
    public static class ParticipleHelp
    {
        public static async Task Participle()
        {
            const string key = "c14436C9w1T6F5z150G92gKYdP9YpHgtdE2LaN0I";//讯飞key
            for (var i = 0; i < DataSource.DataSource1.Count; i++)
            {
                var name = DataSource.DataSource1[i].Name;
                var itemId= DataSource.DataSource1[i].Id;
                var url =
                    $"http://ltpapi.voicecloud.cn/analysis/?api_key={key}&text={name}&pattern=all&format=json";
                var result = await GetResponseStringAsync(url);
                var local = Json.Decode(result)[0][0];
                foreach (var item in local)
                {
                    DataSource.DataSource1[i].Words.Add(new Word
                    {
                        ItemId = itemId,
                        Id = Guid.NewGuid(),
                        Name = item.cont,

                    });
                }
                #region 获取分词信息
                SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgress1, i);
                #endregion
            }
        }
        private static async Task<string> GetResponseStringAsync(string url)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var httpClient = new HttpClient(handler))
            {
                //await异步等待回应
                var response = await httpClient.GetAsync(url);
                //确保HTTP成功状态值
                response.EnsureSuccessStatusCode();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();//加await的意思是说，主ＵＩ等待它执行完成后，再继续执行，这种就叫作并行！
                }
            }
            return null;//error
        }
    }
}
