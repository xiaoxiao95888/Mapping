using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using Mapping.Model;

namespace Mapping.View
{
    public partial class MatchedForm : DevExpress.XtraEditors.XtraForm
    {
        public MatchedForm()
        {
            InitializeComponent();
            Init();
        }
        public int rowhandle;
        public bool HasView;
        public List<InstitutionModel> ExtendedAlias { get; set; }
        private List<InstitutionModel> FilterInstitutionModels { get; set; }
        public void Init()
        {
            ExtendedAlias =
                DataSource.InstitutionModels.SelectMany(ins => ins.UsedNames, (ins, names) => new InstitutionModel
                {
                    Id = ins.Id,
                    Name = names,
                    Type = ins.Type,
                    TypeCode = ins.TypeCode,
                    Address = ins.Address,
                    LocationCode = ins.LocationCode,
                    LocationName = ins.LocationName,
                    Words = ins.Words,
                    UpdateTime = ins.UpdateTime,
                }).Where(n => n.Name != null).ToList();
            gridControl1.DataSource = DataSource.Matcheds;
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView2.Columns)
            {
                item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            }
        }
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DataSource.Matcheds.Any())
            {
                var form = new SheetForm
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
        /// <summary>
        /// 选择匹配的结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var matchedInstitutionModelId = view.GetRowCellValue(view.FocusedRowHandle, "Id") as Guid?;
            var item = (Item)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Item");
            var matched = DataSource.Matcheds.FirstOrDefault(n => n.Item.Id == item.Id);
            var matchedInstitutionModel =
                DataSource.InstitutionModels.FirstOrDefault(n => n.Id == matchedInstitutionModelId);
            if (matchedInstitutionModel != null)
            {
                var model = new MatchedInstitutionModel
                {
                    Id = matchedInstitutionModel.Id,
                    Name = matchedInstitutionModel.Name,
                    Type = matchedInstitutionModel.Type,
                    TypeCode = matchedInstitutionModel.TypeCode,
                    Address = matchedInstitutionModel.Address,
                    LocationCode = matchedInstitutionModel.LocationCode,
                    LocationName = matchedInstitutionModel.LocationName,
                    Words = matchedInstitutionModel.Words,
                    UpdateTime = matchedInstitutionModel.UpdateTime,
                    Percent = 1
                };
                matched.MatchedInstitutionModel = model;
                gridView1.RefreshData();
                gridView2.RefreshData();
            }
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var item = (Item)view.GetRowCellValue(view.FocusedRowHandle, "Item");
            var matched = DataSource.Matcheds.FirstOrDefault(n => n.Item.Id == item.Id);
            if (matched != null)
            {
                HasView = !HasView;
                rowhandle = gridView1.FocusedRowHandle;
                if (item.JoinWords != null)
                {
                    FilterInstitutionModels = ExtendedAlias;
                    //FilterInstitutionModels = DataSource.InstitutionModels.Where(n => n.JoinWords != null).Where(n => item.JoinWords.Any(p => n.Name.Contains(p))).ToList();
                }
                checkedListBoxControl1.Items.Clear();
                checkedListBoxControl2.Items.Clear();
                foreach (var word in item.JoinWords)
                {
                    checkedListBoxControl1.Items.Add(word);
                }
                checkedListBoxControl2.Items.Add(new Location { Name = item.Province, Type = "Province" }, item.Province);
                checkedListBoxControl2.Items.Add(new Location { Name = item.City, Type = "City" }, item.City);
                gridControl2.DataSource = FilterInstitutionModels;
                gridView1.RefreshRow(rowhandle);
            }

        }
        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var words = (from object item in checkedListBoxControl1.CheckedItems select item.ToString()).ToList();//选中的关键字
            //var allwords = (from object item in checkedListBoxControl1.Items select item.ToString()).ToList();//所有关键字
            if (words.Any())
            {
                FilterInstitutionModels = ExtendedAlias.Where(n => words.Count(w => n.Name.Contains(w)) == words.Count).ToList();
            }
            else
            {
                FilterInstitutionModels = ExtendedAlias;
            }
            //if (words.Any())
            //{
            //    FilterInstitutionModels =
            //   DataSource.InstitutionModels.Where(n => n.JoinWords != null).Where(n => words.Count(w => n.Name.Contains(w)) == words.Count).ToList();
            //    //FilterInstitutionModels =
            //    //DataSource.InstitutionModels.Where(n => n.JoinWords != null).Where(n => n.JoinWords.Intersect(words).Count() == words.Count).ToList();
            //}
            //else
            //{
            //    FilterInstitutionModels = DataSource.InstitutionModels.Where(n => n.JoinWords != null).Where(n => allwords.Any(p => n.Name.Contains(p))).ToList();
            //    //FilterInstitutionModels = DataSource.InstitutionModels.Where(n => n.JoinWords != null).Where(n => n.JoinWords.Intersect(allwords).Any()).ToList();
            //}
            var location = new List<Location>();
            for (int i = 0; i < checkedListBoxControl2.Items.Count; i++)
            {
                if (checkedListBoxControl2.GetItemChecked(i))
                {
                    location.Add((Location)checkedListBoxControl2.GetItemValue(i));
                }
            }
            if (location.Any())
            {
                if (location.Any(n => n.Type == "Province"))
                {
                    FilterInstitutionModels = FilterInstitutionModels.Where(n => n.Province == location.Where(p => p.Type == "Province").Select(p => p.Name).FirstOrDefault()).ToList();
                }
                if (location.Any(n => n.Type == "City"))
                {
                    FilterInstitutionModels = FilterInstitutionModels.Where(n => n.City == location.Where(p => p.Type == "City").Select(p => p.Name).FirstOrDefault()).ToList();
                }
            }
            gridControl2.DataSource = FilterInstitutionModels;
        }
        /// <summary>
        /// 取消匹配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var item = (Item)view.GetRowCellValue(view.FocusedRowHandle, "Item");
            var matched = DataSource.Matcheds.FirstOrDefault(n => n.Item.Id == item.Id);
            if (matched != null)
            {
                matched.MatchedInstitutionModel = null;
                gridView1.RefreshData();
                gridView2.RefreshData();
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {

        }
    }
}