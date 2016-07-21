using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Mapping.Helper
{
    public static class HttpHelp
    {
        public static dynamic HttpGet(string url)
        {
            try
            {
                var myWebClient = new WebClient { Credentials = CredentialCache.DefaultCredentials };
                var pageData = myWebClient.DownloadData(url); //从指定网站下载数据  
                var pageHtml = System.Text.Encoding.UTF8.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句
                return Json.Decode(pageHtml);
            }
            catch (WebException webEx)
            {
                //return webEx.Message;
                return null;
            }
        }
    }
}
