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

        public void Init()
        {
            gridControl1.DataSource = DataSource.Matcheds;
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

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var insId = view.GetRowCellValue(view.FocusedRowHandle, "Id") as Guid?;
            var master = (GridView)view.ParentView;
            var item= (Item)master.GetRowCellValue(master.FocusedRowHandle, "Item");
            var matched =
                DataSource.Matcheds.FirstOrDefault(
                    n => n.Item.Id == item.Id);
            if (matched != null)
            {
                var matchedInstitutionModel =
                    matched.MatchedInstitutionModels.FirstOrDefault(n => n.Id == insId);
                if (matchedInstitutionModel != null)
                {
                    var model = new MatchedInstitutionModel
                    {

                        Id = matchedInstitutionModel.Id,
                        Name = matchedInstitutionModel.Name,
                        Type = matchedInstitutionModel.Type,
                        TypeCode = matchedInstitutionModel.TypeCode,
                        Address = matchedInstitutionModel.Address,
                        Location = matchedInstitutionModel.Location,
                        Province = matchedInstitutionModel.Province,
                        City = matchedInstitutionModel.City,
                        District = matchedInstitutionModel.District,
                        Words = matchedInstitutionModel.Words,
                        UpdateTime = matchedInstitutionModel.UpdateTime,
                        Percent = matchedInstitutionModel.Percent

                    };
                    matched.MatchedInstitutionModels.Remove(matchedInstitutionModel);
                    matched.MatchedInstitutionModels.Insert(0, model);
                }
                gridView1.RefreshData();
            }

            //var pt = view.GridControl.PointToClient(MousePosition);
            //var info = view.CalcHitInfo(pt);
            //if (info.InRow || info.InRowCell)
            //{
            //    //数据源中的Index

            //    var insId = view.GetRowCellValue(info.RowHandle, "Id") as Guid?;
            //    var matched =
            //        DataSource.Matcheds.FirstOrDefault(
            //            n => n.MatchedInstitutionModels.Any(p => p.Id == insId));
            //    if (matched != null)
            //    {
            //        var matchedInstitutionModel =
            //            matched.MatchedInstitutionModels.FirstOrDefault(n => n.Id == insId);
            //        if (matchedInstitutionModel != null)
            //        {
            //            var model = new MatchedInstitutionModel
            //            {

            //                Id = matchedInstitutionModel.Id,
            //                Name = matchedInstitutionModel.Name,
            //                Type = matchedInstitutionModel.Type,
            //                TypeCode = matchedInstitutionModel.TypeCode,
            //                Address = matchedInstitutionModel.Address,
            //                Location = matchedInstitutionModel.Location,
            //                Province = matchedInstitutionModel.Province,
            //                City = matchedInstitutionModel.City,
            //                District = matchedInstitutionModel.District,
            //                Words = matchedInstitutionModel.Words,
            //                UpdateTime = matchedInstitutionModel.UpdateTime,
            //                Percent = matchedInstitutionModel.Percent

            //            };
            //            matched.MatchedInstitutionModels.Remove(matchedInstitutionModel);
            //            matched.MatchedInstitutionModels.Insert(0, model);
            //        }
            //        gridView1.RefreshData();
            //    }
            //}
        }
    }
}