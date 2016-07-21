using Mapping.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Mapping.Helper;

namespace Mapping
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {

            InitializeComponent();
            Init();
        }

        private void btn_importexcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectExcel();
            //var importData = new ImportData
            // {
            //     StartPosition = FormStartPosition.CenterParent
            // };
            // importData.ShowDialog();
        }

        private async void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgressMax, DataSource.DataSource1.Count);
            //await ParticipleHelp.Participle();
            await LocaltionHelp.Localtion();
            //Close Wait Form
            SplashScreenManager.CloseForm(false);

        }

        public void Init()
        {
            this.gridControl1.DataSource = DataSource.DataSource1;
            // this.gridControl2.DataSource = DataSource.DataSource2;
        }
        /// <summary>
        /// 选择excel
        /// </summary>
        public void SelectExcel()
        {
            var fileDialog = new OpenFileDialog { Filter = "excel|*.xlsx;*.xls" };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fileDialog.FileName))
                {
                    try
                    {
                        var result = ExcelHelper.GetDataFromExcel<Item>(fileDialog.FileName).Where(n => n.Code != null).ToList();
                        result.ForEach(n => n.Id = Guid.NewGuid());
                        DataSource.DataSource1.Clear();
                        foreach (var item in result)
                        {
                            DataSource.DataSource1.Add(item);
                        }
                        if (DataSource.DataSource1.Any())
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("成功", "提示");
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("成功", "提示");
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("操作失败", "提示");
                    }
                }
            }
        }
    }
}
