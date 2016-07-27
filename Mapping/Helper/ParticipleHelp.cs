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
        const string Key = "c14436C9w1T6F5z150G92gKYdP9YpHgtdE2LaN0I";//讯飞key
        public static async Task Participle()
        {
            var num = DataSource.DataSource1.Count;
            for (var i = 0; i < num; i++)
            {
                var name = DataSource.DataSource1[i].Name;
                var itemId = DataSource.DataSource1[i].Id;
                DataSource.DataSource1[i].Words.Clear();
                var url =
                    $"http://ltpapi.voicecloud.cn/analysis/?api_key={Key}&text={name}&pattern=all&format=json";
                var result = await GetResponseStringAsync(url);
                //为保障系统稳定，语言云API的使用频率默认限制为每个IP 200次/秒。
                await Task.Delay(7);
                if (result != null)
                {
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
                }
                #region 获取分词信息
                SplashScreenTool.SendCommand(WaitForm1.WaitFormCommand.SetProgress1,
                    Convert.ToInt32((i + 1)/(decimal) num*100));
                #endregion
            }
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
