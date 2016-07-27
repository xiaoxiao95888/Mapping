using Mapping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using Mapping.DbModel;
using Mapping.Helper;
using Mapping.Service;
using Mapping.View;

namespace Mapping
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            Init();
        }

        private void btn_importexcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectExcel();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {          
            //并行
            SplashScreenTool.ShowSplashScreen(typeof(WaitForm1));
            new Action(async () =>
            {
                await ParticipleHelp.Participle();
                await LocaltionHelp.Localtion();
                SplashScreenManager.CloseForm(true);
            })();
        }

        public void Init()
        {
            this.gridControl1.DataSource = DataSource.DataSource1;
        }
        /// <summary>
        /// 加载数据库主数据
        /// </summary>
        private async void LoadInstitutions()
        {
            SplashScreenTool.ShowSplashScreen(typeof(SplashScreen1));
            //.ShowForm(this, typeof(SplashScreen1), true, true, false);
            DataSource.Institutions = GetInstitutions().Result;
            gridControl3.DataSource = DataSource.Institutions;
            SplashScreenManager.CloseForm(false);
        }
        private static Task<List<Institution>> GetInstitutions()
        {
            return Task.Run(() => DbService.InstitutionService.GetAll().ToList());
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
                        DevExpress.XtraEditors.XtraMessageBox.Show($"导入{DataSource.DataSource1.Count}条数据", "提示");

                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("导入失败", "提示");
                    }
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                var itemId = view.GetRowCellValue(info.RowHandle, "Id") as Guid?;

                DataSource.SelectedItem = DataSource.DataSource1.FirstOrDefault(n => n.Id == itemId);
                this.gridControl2.DataSource = DataSource.SelectedItem.Places;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataSource.SelectedItem.Places != null)
            {
                var manualForm = new ManualForm { StartPosition = FormStartPosition.CenterParent };
                manualForm.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInstitutions();
        }
        /// <summary>
        /// 选择一条Place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void targetGridView_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                var placeId = view.GetRowCellValue(info.RowHandle, "Id").ToString();
                DataSource.SelectedPlace = DataSource.SelectedItem.Places.FirstOrDefault(n => n.Id == placeId);
                if (DataSource.SelectedPlace != null)
                {
                    ced_province.Text = DataSource.SelectedPlace.Province;
                    ced_city.Text = DataSource.SelectedPlace.City;
                    ced_county.Text = DataSource.SelectedPlace.District;
                    ced_type.Text = DataSource.SelectedPlace.TypeCode;
                    ced_province.Visible =
                        ced_city.Visible = ced_county.Visible = ced_type.Visible = ced_participle.Visible = btn_confirm.Visible = true;
                    //ced_province.Checked =
                    //    ced_city.Checked = ced_county.Checked = ced_type.Checked = ced_participle.Checked = true;
                    FilterIns();
                }
            }
        }

        private async void FilterIns()
        {
            var data = DataSource.Institutions.Where(n =>
                (!ced_province.Checked || (n.Province == ced_province.Text))
                && (!ced_city.Checked || (n.City == ced_city.Text))
                && (!ced_county.Checked || (n.District == ced_county.Text))
                && (!ced_type.Checked || (n.TypeCode == ced_type.Text))
                );
            if (ced_participle.Checked)
            {
                var words = await ParticipleHelp.GetParticiple(DataSource.SelectedPlace.Name);
                if (words.Any())
                {
                    data =
                    data.Select(n => new { number = words.Count(x => n.Name.Contains(x)), item = n })
                        .OrderByDescending(n => n.number)
                        .Select(n => n.item);
                }
            }
            gridControl3.DataSource = data;
        }
        private void ced_CheckStateChanged(object sender, EventArgs e)
        {
            FilterIns();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var autoprocessForm = new AutoprocessForm { StartPosition = FormStartPosition.CenterParent };
            autoprocessForm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var baseDataForm = new BaseDataForm { StartPosition = FormStartPosition.CenterParent };
            baseDataForm.ShowDialog();
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
