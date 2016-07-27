using System;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraSplashScreen;
using Mapping.Helper;

namespace Mapping.View
{
    public partial class BaseDataForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseDataForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gridControl1.DataSource = DataSource.Institutions;
        }

        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SplashScreenTool.ShowSplashScreen(typeof(ParticipleWaitForm));
            splashScreenManager1.ShowWaitForm();
            await Participle();
            splashScreenManager1.CloseWaitForm();
        }

        private async Task Participle()
        {var num = DataSource.Institutions.Count;
            for (var i = 0; i < num; i++)
            {
                var words = await ParticipleHelp.GetParticiple(DataSource.Institutions[i].Name);
                if (words.Any())
                {
                    gridControl1.BeginUpdate();
                    DataSource.Institutions[i].Words = string.Join(",", words);
                    DbService.InstitutionService.Update();
                    gridControl1.EndUpdate();
                }
                SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetProgress1,
                Convert.ToInt32((i + 1) / (decimal)num * 100));
            }
        }
    }
}