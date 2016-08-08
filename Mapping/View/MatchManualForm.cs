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
    public partial class MatchManualForm : DevExpress.XtraEditors.XtraForm
    {
        public MatchManualForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            lblname.Text = DataSource.SelectedMatched.Item.Name;
            lbladdress.Text = DataSource.SelectedMatched.Item.Address;
            cbxtypecode.Text = DataSource.SelectedMatched.Item.TypeCode;
            lbltype.Text = DataSource.SelectedMatched.Item.Type;
            cbxprovince.Text = DataSource.SelectedMatched.Item.Province;
            cbxcity.Text = DataSource.SelectedMatched.Item.City;
            cbxdistrict.Text = DataSource.SelectedMatched.Item.District;
            cbxprovince.Visible = !string.IsNullOrEmpty(cbxprovince.Text);
            cbxcity.Visible = !string.IsNullOrEmpty(cbxcity.Text);
            cbxdistrict.Visible = !string.IsNullOrEmpty(cbxdistrict.Text);
            searchLookUpEdit1.Properties.DataSource = DataSource.SelectedMatched.MatchedInstitutionModels;
            searchLookUpEdit1.Properties.View = searchLookUpEdit1View;
        }
    }
}