using Mapping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using Mapping.Helper;
using Mapping.View;

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
        }

        private async void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.SetProgressMax, DataSource.DataSource1.Count);
            await ParticipleHelp.Participle();
            await LocaltionHelp.Localtion();
            //Close Wait Form
            SplashScreenManager.CloseForm(false);
        }

        public void Init()
        {
            this.gridControl1.DataSource = DataSource.DataSource1;
            
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
                        result.ForEach(n =>
                        {
                            n.Id = Guid.NewGuid();
                            n.Places = new List<Place>();
                            n.Words = new List<Word>();
                        });
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var dsadas = DataSource.DataSource1;
            var test = new Test { StartPosition = FormStartPosition.CenterParent };
            test.ShowDialog();}

        private void gridView1_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
                var pt = view.GridControl.PointToClient(MousePosition);
                var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                        var itemId = view.GetRowCellValue(info.RowHandle, "Id")as Guid?;
             
                DataSource.SelectedItem = DataSource.DataSource1.FirstOrDefault(n => n.Id == itemId);
                this.gridControl2.DataSource = DataSource.SelectedItem.Places;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataSource.SelectedItem.Places!=null)
            {
                var manualForm = new ManualForm { StartPosition = FormStartPosition.CenterParent };
                manualForm.ShowDialog();
            }
        }



        //private void gridView3_DoubleClick(object sender, EventArgs e)
        //{
        //    var view = (GridView)sender;
        //    var pt = view.GridControl.PointToClient(MousePosition);
        //    var info = view.CalcHitInfo(pt);
        //    if (info.InRow || info.InRowCell)
        //    {
        //        //数据源中的Index
        //        var placeId = view.GetRowCellValue(info.RowHandle, "Id").ToString();
        //        DataSource.SelectedPlace =
        //            DataSource.DataSource1.SelectMany(n => n.Places).FirstOrDefault(n => n.Id == placeId);
        //        DataSource.SelectedItem = DataSource.DataSource1.FirstOrDefault(n => n.Id == DataSource.SelectedPlace.ItemId);
        //        var matchForm = new MatchForm
        //        {
        //            StartPosition = FormStartPosition.CenterParent
        //        };
        //        matchForm.ShowDialog();
        //    }
        //}
    }

}
