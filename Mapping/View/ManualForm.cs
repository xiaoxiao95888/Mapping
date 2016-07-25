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
using Mapping.Helper;
using Mapping.Model;

namespace Mapping.View
{
    public partial class ManualForm : DevExpress.XtraEditors.XtraForm
    {
        public ManualForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            textBox1.Text = DataSource.SelectedItem.Name;
        }

        private async void BindGrid()
        {
            var city = searchLookUpEdit1.EditValue?.ToString();
            var name = textBox1.Text;
            if (string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(city) == false)
            {
                await LocaltionHelp.GetPlace(name, city);
            }
            else
            {
                DataSource.SelectedItem.Places = new List<Place>();
            }
            gridControl1.DataSource = DataSource.SelectedItem.Places;
        }

        private async void TextBoxTextChange()
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var result = await LocaltionHelp.GetSuggestion(textBox1.Text);
                searchLookUpEdit1.Properties.DataSource = result;
            }
            else
            {
                searchLookUpEdit1.Properties.DataSource = null;
            }
            searchLookUpEdit1.Properties.View = searchLookUpEdit1View;
            BindGrid();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChange();
        }
        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}