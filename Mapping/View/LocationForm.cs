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
using Mapping.DbModel;
using Mapping.Model;

namespace Mapping.View
{
    public partial class LocationForm : DevExpress.XtraEditors.XtraForm
    {
        public List<InstitutionModel> InstitutionModels { get; set; }
        public List<Place> Place { get; set; }
        public InstitutionModel SelectedInstitutionModel { get; set; }
        public LocationForm(List<InstitutionModel> institutionModels, List<Place> places)
        {
            this.InstitutionModels = institutionModels;
            this.Place = places;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            gridControl1.DataSource = InstitutionModels;
        }
       
        /// <summary>
        /// 主数据选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_Click(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                var itemId = view.GetRowCellValue(info.RowHandle, "Id") as Guid?;
                SelectedInstitutionModel = InstitutionModels.FirstOrDefault(n => n.Id == itemId);
                gridControl2.DataSource = Place.Where(n => n.ItemId == itemId).ToArray();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            var view = gridView2;
            var pt = view.GridControl.PointToClient(MousePosition);
            var info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //数据源中的Index
                var placeId = view.GetRowCellValue(info.RowHandle, "Id").ToString();
                var place = Place.FirstOrDefault(n => n.Id == placeId);
                if (place != null)
                {
                    var item = InstitutionModels.FirstOrDefault(n => n.Id == place.ItemId);
                    if (item != null)
                    {
                        item.TypeCode = place.TypeCode;
                        //item.LocationName = place.LocationName;
                        //item.Province = place.Province;
                        //item.City = place.City;
                        //item.District = place.District;
                        item.Address = place.Address;
                        gridView1.RefreshData();
                    }
                }
            }
        }
        private void BaseDataManualForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = (BaseDataManualForm) sender;
            var places = form.Places;
            if (places != null && places.Any())
            {
                var remove = Place.Where(n => n.ItemId == SelectedInstitutionModel.Id).ToArray();
                foreach (var place in remove)
                {
                    Place.Remove(place);
                }
                Place.AddRange(places);
                gridView1.RefreshData();
                gridControl2.DataSource = Place.Where(n => n.ItemId == SelectedInstitutionModel.Id).ToArray();
            }
        }
        //手动获取
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectedInstitutionModel != null)
            {
                var baseDataManualForm = new BaseDataManualForm
                {
                    StartPosition = FormStartPosition.CenterParent,
                    InstitutionModel = SelectedInstitutionModel
                };
                baseDataManualForm.FormClosed += BaseDataManualForm_FormClosed;
                baseDataManualForm.ShowDialog();
            }
        }
    }
}