using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using DevExpress.XtraSplashScreen;
using Mapping.Model;

namespace Mapping.Helper
{
    public static class LocaltionHelp
    {
        public static async Task Localtion()
        {
            //const string key = "wpnLFgvCKjUk4IAq2P3yzyGFPOzAQC2l";
            const string key = "0e5d423fdc3296a4212cce56cc52d2a6";//高德key
            for (var i = 0; i < DataSource.DataSource1.Count; i++)
            {
                var name = DataSource.DataSource1[i].Name;
                var itemId = DataSource.DataSource1[i].Id;
                var itemCode = DataSource.DataSource1[i].Code;
                var url =
                    $"http://restapi.amap.com/v3/place/text?key={key}&keywords={name}&types=&city=&children=1&offset=20&page=1&extensions=base";
                var result = await GetResponseStringAsync(url);
                var local = Json.Decode(result);
                if (local != null && local.pois.Length != 0)
                {
                    foreach (var item in local.pois)
                    {
                        DataSource.DataSource1[i].Places.Add(new Place
                        {
                            ItemId = itemId,
                            ItemCode = itemCode,
                            Id = item.id,
                            Name = item.name,
                            Type = item.type,
                            TypeCode = item.typecode,
                            Address = item.address,
                            Location = item.location,
                            Province = item.pname,
                            City = item.cityname,
                            District = item.adname
                        });
                    }
                }
                #region 获取地理信息
                SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgress2, i);
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
