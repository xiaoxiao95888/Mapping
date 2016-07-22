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

namespace Mapping.View
{
    public partial class MatchForm : DevExpress.XtraEditors.XtraForm
    {
        public MatchForm()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            lblname.Text = DataSource.SelectedItem.Name;
            lbladdress.Text = DataSource.SelectedPlace.Address;
            lbltypecode.Text = DataSource.SelectedPlace.TypeCode;
            lbltype.Text = DataSource.SelectedPlace.Type;
            cbxprovince.Text = DataSource.SelectedPlace.Province;
            cbxcity.Text = DataSource.SelectedPlace.City;
            cbxdistrict.Text = DataSource.SelectedPlace.District;
            cbxprovince.Visible = !string.IsNullOrEmpty(cbxprovince.Text);
            cbxcity.Visible = !string.IsNullOrEmpty(cbxcity.Text);
            cbxdistrict.Visible = !string.IsNullOrEmpty(cbxdistrict.Text);        
            searchLookUpEdit1.Properties.DataSource=DataSource.SelectedItem;
            searchLookUpEdit1.Properties.View = searchLookUpEdit1View;          
        }
    }
}