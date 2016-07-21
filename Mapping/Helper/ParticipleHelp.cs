using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;

namespace Mapping.Helper
{
    public static class ParticipleHelp
    {
        public static async Task Participle()
        {
            for (int i = 0; i < DataSource.DataSource1.Count; i++)
            {
                var name = DataSource.DataSource1[i].Name;
                #region 获取分词
                DataSource.DataSource1[i].Words = null;
                SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgress1, i);
                #endregion
            }






            MemoryStream content = new MemoryStream();
            // 对MSDN发起一个Web请求  
            HttpWebRequest webRequest = WebRequest.Create("http://msdn.microsoft.com/zh-cn/") as HttpWebRequest;
            if (webRequest != null)
            {
                // 返回回复结果  
                using (WebResponse response = await webRequest.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);
                    }
                }
            }
        }
    }
}
