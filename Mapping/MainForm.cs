using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Mapping.Helper;
using Mapping.Model;
using Mapping.View;

namespace Mapping
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
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
        private IEnumerable<Item> GetSelected()
        {
            var selectedHandle = MasterView.GetSelectedRows();
            var selectedIds = selectedHandle.Select(handle => MasterView.GetRowCellValue(handle, "Id"));
            //var result = from id in selectedIds
            //             join source in DataSource.Institutions on id.ToString() equals source.Id.ToString() into r1
            //             from item in r1.DefaultIfEmpty()
            //             select item;
            var result =
                selectedIds.GroupJoin(DataSource.DataSource1, id => id.ToString(), source => source.Id.ToString(),
                    (id, r1) => new { id, r1 }).SelectMany(@t => @t.r1.DefaultIfEmpty());

            return result;
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //并行
            SplashScreenTool.ShowSplashScreen(this, typeof(WaitForm1));
            var items = GetSelected().ToList();
            var task1 = Segmentation(items);
            var task2 = Localtion(items.Where(n => string.IsNullOrEmpty(n.Province) || string.IsNullOrEmpty(n.City)).ToList());
            new Action(async () =>
            {
                await task1;
                await task2;
                SplashScreenTool.CloseSplashScreen();
                MasterView.RefreshData();
                SubView.RefreshData();
                //SbExpandDetails();
            })();
        }
        //分词
        public async Task Segmentation(List<Item> items)
        {
            var num = items.Count;
            var i = 0;
            foreach (var item in items)
            {
                i++;
                var words = await ParticipleHelp.PostParticiple(item.Name);
                item.Words = string.Join(",", words);
                SplashScreenTool.SendCommand(WaitForm1.WaitFormCommand.SetProgress1,
                    Convert.ToInt32(i / (decimal)num * 100));
            }
        }
        /// <summary>
        /// 地理信息
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task Localtion(List<Item> items)
        {
            var num = items.Count;
            var i = 0;
            foreach (var item in items)
            {
                i++;
                item.Places =
                    await LocaltionHelp.GetOnePlace(item.Name, item.City + item.District, item.TypeCode, item.Id);
                //默认取值第一个
                var firstPlace = item.Places.FirstOrDefault();
                if (firstPlace != null)
                {
                    item.Province = firstPlace.Province;
                    item.City = firstPlace.City;
                    item.District = firstPlace.District;
                    item.Type = firstPlace.Type;
                    item.TypeCode = firstPlace.TypeCode;
                    item.Address = firstPlace.Address;
                }
                SplashScreenTool.SendCommand(WaitForm1.WaitFormCommand.SetProgress2,
                    Convert.ToInt32(i / (decimal)num * 100));
            }
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
            SplashScreenTool.ShowSplashScreen(this, typeof(SplashScreen1));//.ShowForm(this, typeof(SplashScreen1), true, true, false);
            DataSource.InstitutionModels = GetInstitutions().Result;
            //gridControl3.DataSource = DataSource.InstitutionModels;
            SplashScreenManager.CloseForm(false);
        }
        private static Task<List<InstitutionModel>> GetInstitutions()
        {
            return Task.Run(() => DbService.InstitutionService.GetAll().Select(n => new InstitutionModel
            {
                Id = n.Id,
                Name = n.Name,
                Type = n.Type,
                TypeCode = n.TypeCode,
                Address = n.Address,
                LocationCode = n.LocationCode,
                LocationName = n.LocationName,
                Words = n.Words,UpdateTime = n.UpdateTime,
                UsedNames = n.InstitutionNames.Select(p=>p.UsedName).Distinct().ToList()
            }).ToList());
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
                        });
                        DataSource.DataSource1.Clear();
                        foreach (var item in result)
                        {
                            DataSource.DataSource1.Add(item);
                        }
                        XtraMessageBox.Show($"导入{DataSource.DataSource1.Count}条数据", "提示");

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("导入失败", "提示");
                    }
                    MasterView.RefreshData();
                }
            }
        }
        //展开所有
        private void SbExpandDetails()
        {
            MasterView.BeginUpdate();
            try
            {
                for (int i = 0; i < MasterView.RowCount; i++)
                    MasterView.SetMasterRowExpanded(i, true);
            }
            finally
            {
                MasterView.EndUpdate();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadInstitutions();
        }
        /// <summary>
        /// 点击匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSource.Matcheds = new BindingList<Matched>();
            foreach (var item in DataSource.DataSource1)
            {
                MatchedHelper.Matched(item);
            }
            var matchedForm = new MatchedForm { StartPosition = FormStartPosition.CenterParent };
            matchedForm.ShowDialog();

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var baseDataForm = new BaseDataForm { StartPosition = FormStartPosition.CenterParent };
            baseDataForm.ShowDialog();
        }
        //选中搜索的结果
        private void SubView_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                var placeId = view.GetRowCellValue(info.RowHandle, "Id").ToString();
                var place =
                    DataSource.DataSource1.SelectMany(n => n.Places).FirstOrDefault(n => n.Id == placeId);
                if (place != null)
                {
                    var item = DataSource.DataSource1.FirstOrDefault(n => n.Id == place.ItemId);
                    if (item != null)
                    {
                        item.Province = place.Province;
                        item.City = place.City;
                        item.District = place.District;
                        item.TypeCode = place.TypeCode;
                        item.Type = place.Type;
                        item.Address = place.Address;
                        MasterView.RefreshData();
                    }
                }
            }
        }

        private void MasterView_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {

                //数据源中的Index
                var itemId = view.GetRowCellValue(info.RowHandle, "Id") as Guid?;
                DataSource.SelectedItem = DataSource.DataSource1.FirstOrDefault(n => n.Id == itemId);
                if (DataSource.SelectedItem != null)
                {
                    if (DataSource.SelectedItem.Places != null)
                    {
                        var manualForm = new ManualForm { StartPosition = FormStartPosition.CenterParent };
                        manualForm.FormClosed += ManualForm_FormClosed;
                        manualForm.ShowDialog();
                    }
                }
            }
        }

        private void ManualForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MasterView.RefreshData();
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }
        /// <summary>
        /// 导出分析的结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataSource.DataSource1.Any())
            {
                var form = new SheetFormProcessingResult
                {
                    StartPosition = FormStartPosition.CenterParent,
                    WindowState = FormWindowState.Maximized
                };
                form.Show();
            }
            else
            {
                XtraMessageBox.Show("没有任何匹配的结果", "提示");
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