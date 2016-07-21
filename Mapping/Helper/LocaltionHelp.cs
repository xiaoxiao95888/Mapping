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
            const string key = "wpnLFgvCKjUk4IAq2P3yzyGFPOzAQC2l";
            for (int i = 0; i < DataSource.DataSource1.Count; i++)
            {
                var name = DataSource.DataSource1[i].Name;
                //第一步调用search，结果不包含城市区县等信息
                var url =
                    $"http://api.map.baidu.com/place/v2/search?q={name}&region=全国&output=json&ak={key}";
                var result = await GetResponseStringAsync(url);
                var local = Json.Decode(result);
                if (local != null && local.results.Length != 0)
                {
                    var places= new List<Place>();
                    foreach (var item in local.results)
                    {
                        if (item.location.Length != 0)
                        {
                            var place = new Place
                            {
                                Location = new Location
                                {
                                    Lat = item.location.lat,
                                    Lng = item.location.lng
                                },
                                Uid = item.uid,
                                Name = item.name,
                                Address = item.address
                            };
                            //第二部调用Geocoding API 将坐标转换成地址
                            //places.Add(new Place { City = item.city, District = item.district, });
                        }

                    }
                }

                #region 获取地理信息
                DataSource.DataSource1[i].Place = null;
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
