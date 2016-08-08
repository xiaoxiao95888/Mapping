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
            this.Closing += ManualForm_Closing;
        }

        private void ManualForm_Closing(object sender, CancelEventArgs e)
        {
            if (Places != null)
            {
                var items = GetSelected().ToList();
                if (items.Any())
                {
                    var firstPlace = items.FirstOrDefault();
                    DataSource.SelectedItem.Places.Clear();
                    foreach (var item in items)
                    {
                        DataSource.SelectedItem.Places.Add(item);
                    }
                    if (firstPlace != null)
                    {
                        DataSource.SelectedItem.Province = firstPlace.Province;
                        DataSource.SelectedItem.City = firstPlace.City;
                        DataSource.SelectedItem.District = firstPlace.District;
                        DataSource.SelectedItem.TypeCode = firstPlace.TypeCode;
                        DataSource.SelectedItem.Type = firstPlace.Type;
                        DataSource.SelectedItem.Address = firstPlace.Address;
                    }
                }
            }
        }
        public  List<Place> Places { get; set; } 
        private async void BindGrid()
        {
            var city = searchLookUpEdit1.EditValue?.ToString();
            var name = textBox1.Text;
            if (string.IsNullOrEmpty(name) == false)
            {
                Places =
                    await
                        LocaltionHelp.GetOnePlace(name, city, null,
                            DataSource.SelectedItem.Id, 20);
                gridControl1.DataSource = Places;
            }
        }

        private async void TextBoxTextChange()
        {
            var text = textBox1.Text;
            if (!string.IsNullOrEmpty(text))
            {
                var result = await LocaltionHelp.GetSuggestion(textBox1.Text, null);
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
        private IEnumerable<Place> GetSelected()
        {
            if (Places != null)
            {
                var selectedHandle = gridView1.GetSelectedRows();
                var selectedIds = selectedHandle.Select(handle => gridView1.GetRowCellValue(handle, "Id"));
                //var result = from id in selectedIds
                //             join source in DataSource.Institutions on id.ToString() equals source.Id.ToString() into r1
                //             from item in r1.DefaultIfEmpty()
                //             select item;
                var result =
                    selectedIds.GroupJoin(Places, id => id.ToString(), source => source.Id.ToString(),
                        (id, r1) => new {id, r1}).SelectMany(@t => @t.r1.DefaultIfEmpty());

                return result;
            }
            return null;
        }
    }
}