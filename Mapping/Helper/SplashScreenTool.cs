using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Mapping.Helper
{
    public static class SplashScreenTool
    {
        private const bool FadeIn = false;
        private const bool FadeOut = true;
        private const bool ThrowExceptionIfIsAlreadyShown = false;
        private const bool ThrowExceptionIfIsAlreadyClosed = false;

        /// <summary>
        /// ShowSplashScreen
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="type">WaitForm</param>
        public static void ShowSplashScreen(Form parentForm, Type type)
        {
            CloseSplashScreen();
            SplashScreenManager.ShowForm(parentForm, type, FadeIn, FadeOut, SplashFormStartPosition.Default, new Point(0, 0), ParentFormState.Locked);
        }
        
        /// <summary>
        /// CloseSplashScreen
        /// </summary>
        public static void CloseSplashScreen()
        {
            if (SplashScreenManager.Default != null)
            {
                //Thread _task = new Thread(() =>
                //{
                SplashScreenManager.CloseForm(ThrowExceptionIfIsAlreadyClosed);
                //});
                //_task.Start();
            }
        }
        /// <summary>
        /// SetCaption
        /// </summary>
        /// <param name="caption">需要设置的Title</param>
        public static void SetCaption(string caption)
        {
            if (SplashScreenManager.Default != null && !string.IsNullOrEmpty(caption))
            {
                SplashScreenManager.Default.SetWaitFormCaption(caption);
            }
        }
        /// <summary>
        /// SetDescription
        /// </summary>
        /// <param name="description">需要设置的文字提示信息</param>
        public static void SetDescription(string description)
        {
            if (SplashScreenManager.Default != null && !string.IsNullOrEmpty(description))
            {
                SplashScreenManager.Default.SetWaitFormDescription(description);
            }
        }

        public static void SendCommand(Enum cmd, object arg)
        {
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.Default.SendCommand(cmd, arg);
            }
         
        }
    }
}
