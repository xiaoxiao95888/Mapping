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
        public List<Institution> Institutions { get; set; }
        public List<Place> Place { get; set; }
        public LocationForm(List<Institution> institutions, List<Place> places)
        {
            this.Institutions = institutions;
            this.Place = places;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            gridControl1.DataSource = Institutions;
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
                    var item = Institutions.FirstOrDefault(n => n.Id == place.ItemId);
                    if (item != null)
                    {
                        item.TypeCode = place.TypeCode;
                        item.Province = place.Province;
                        item.City = place.City;
                        item.District = place.District;
                        item.Address = place.Address;
                        gridView1.RefreshData();
                    }
                }
            }
        }
    }
}