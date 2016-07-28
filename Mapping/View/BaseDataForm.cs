using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using Mapping.DbModel;
using Mapping.Helper;
using Mapping.Model;

namespace Mapping.View
{
    public partial class BaseDataForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseDataForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gridControl1.DataSource = DataSource.Institutions;
        }

        private IEnumerable<Institution> GetSelected()
        {
            var selectedHandle = gridView1.GetSelectedRows();
            var selectedIds = selectedHandle.Select(handle => gridView1.GetListSourceRowCellValue(handle, "Id"));
            //var result = from id in selectedIds
            //             join source in DataSource.Institutions on id.ToString() equals source.Id.ToString() into r1
            //             from item in r1.DefaultIfEmpty()
            //             select item;
            var result =
                selectedIds.GroupJoin(DataSource.Institutions, id => id.ToString(), source => source.Id.ToString(),
                    (id, r1) => new { id, r1 }).SelectMany(@t => @t.r1.DefaultIfEmpty());

            return result;

        }
        /// <summary>
        /// 分词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenTool.ShowSplashScreen(this, typeof(ParticipleWaitForm));
            SplashScreenTool.SetCaption("分词进度");
            await Participle();
            gridView1.RefreshData();
            SplashScreenTool.CloseSplashScreen();
        }
        private async void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenTool.ShowSplashScreen(this, typeof(ParticipleWaitForm));
            SplashScreenTool.SetCaption("地理进度");
            var places= await Localtion();
            var form = new LocationForm(GetSelected().ToList(), places)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            form.FormClosed += Form_FormClosed;
            SplashScreenTool.CloseSplashScreen();
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridView1.RefreshData();
        }

        private async Task Participle()
        {
            var filters = GetSelected().ToList();
            if (filters.Any())
            {
                var num = filters.Count;
                SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetTotal, num);
                for (var i = 0; i < num; i++)
                {
                    SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetCurrent, i + 1);
                    var words = await ParticipleHelp.GetParticiple(filters[i].Name);
                    if (words.Any())
                    {
                        filters[i].Words = string.Join(",", words);
                        //DbService.InstitutionService.Update();
                        SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetSucceed, i + 1);
                    }
                    SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetProgress,
                    Convert.ToInt32((i + 1) / (decimal)num * 100));
                }
            }
        }

        private async Task<List<Place>> Localtion()
        {
            var places = new List<Place>();
            var filters = GetSelected().ToList();
            if (filters.Any())
            {
                var num = filters.Count;
                SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetTotal, num);
                for (var i = 0; i < num; i++)
                {
                    SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetCurrent, i + 1);
                    var city = filters[i].City + filters[i].District;
                    var result = await LocaltionHelp.GetOnePlace(filters[i].Name,city, filters[i].Id);if (result.Any())
                    {
                        places.AddRange(result);
                        //DbService.InstitutionService.Update();
                        SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetSucceed, i + 1);
                    }
                    SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetProgress,
                        Convert.ToInt32((i + 1)/(decimal) num*100));
                }
            }
            return places;
        }
    }
}