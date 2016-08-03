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
using Mapping.Service;

namespace Mapping.Helper
{
    public static class LocaltionHelp
    {
        //const string Key = "0e5d423fdc3296a4212cce56cc52d2a6";//高德key
        const string Key = "ebef24172cabd898c413045b5731ee6c";//高德key
        /// <summary>
        /// 获取推荐的城市
        /// </summary>
        /// <param name="name">关键字</param>
        /// <param name="typecode">行业编码</param>
        /// <returns></returns>
        public static async Task<List<SuggestionCity>> GetSuggestion(string name, string typecode)
        {
            var url =
                  $"http://restapi.amap.com/v3/place/text?key={Key}&keywords={name}&types{typecode}=&city=&children=1&offset=20&page=1&extensions=base";
            var result = await GetResponseStringAsync(url);

            var json = Json.Decode(result);
            if (json != null && json.suggestion.cities.Length != 0)
            {
                var list = new List<SuggestionCity>();
                foreach (var item in json.suggestion.cities)
                {
                    list.Add(new SuggestionCity
                    {
                        AdCode = item.adcode,
                        CityName = item.name,
                        CityCode = item.citycode,
                        Num = Convert.ToInt32(item.num)
                    });
                }
                return list;
            }
            return null;

        }
        public static async Task<List<Place>> GetOnePlace(string name, string citycode, string typecode, Guid itemId, int offset = 5)
        {
            var places = new List<Place>();
            try
            {
                var url =
                  $"http://restapi.amap.com/v3/place/text?key={Key}&keywords={name}&types={typecode}&city={citycode}&children=1&offset={offset}&page=1&extensions=base";
                var result = await GetResponseStringAsync(url);
                var json = Json.Decode(result);
                if (json != null && json.pois.Length != 0)
                {
                    foreach (var item in json.pois)
                    {
                        places.Add(new Place
                        {
                            Id = item.id,
                            ItemId = itemId,
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
            }
            catch (Exception)
            {

            }

            return places;
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
