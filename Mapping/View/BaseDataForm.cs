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
            gridControl1.DataSource = DataSource.InstitutionModels;
        }

        private IEnumerable<InstitutionModel> GetSelected()
        {
            var selectedHandle = gridView1.GetSelectedRows();
            var selectedIds = selectedHandle.Select(handle => gridView1.GetRowCellValue(handle, "Id"));

            //var result = from id in selectedIds//             join source in DataSource.Institutions on id.ToString() equals source.Id.ToString() into r1
            //             from item in r1.DefaultIfEmpty()
            //             select item;
            var result =
                selectedIds.GroupJoin(DataSource.InstitutionModels, id => id.ToString(), source => source.Id.ToString(),
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
            var places = await Localtion();
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
                    var words = await ParticipleHelp.PostParticiple(filters[i].Name);
                    if (words.Any())
                    {
                        filters[i].Words = string.Join(",", words);
                        //DbService.InstitutionService.Update();
                        //暂时直接保存
                        DbService.InstitutionService.UpdateParticiple(filters[i]);
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
                    var result = await LocaltionHelp.GetOnePlace(filters[i].Name, city, filters[i].TypeCode, filters[i].Id, 20);
                    if (result.Any())
                    {
                        places.AddRange(result);
                        //DbService.InstitutionService.Update();
                        SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetSucceed, i + 1);
                    }
                    SplashScreenTool.SendCommand(ParticipleWaitForm.WaitFormCommand.SetProgress,
                        Convert.ToInt32((i + 1) / (decimal)num * 100));
                }
            }
            return places;
        }
        private async Task SaveBase()
        {
            var items = GetSelected().ToList();
            var i = 0;
            var sum = items.Count;
            foreach (var item in items)
            {
                i++;
                SplashScreenTool.SendCommand(SaveBaseDataWaitForm.WaitFormCommand.SetProgress,
                    Convert.ToInt32((i) / (decimal)sum * 100));
                var data = DbService.InstitutionService.GetInstitution(item.Id);

                if (data != null)
                {
                    SplashScreenTool.SendCommand(SaveBaseDataWaitForm.WaitFormCommand.SetInstitution,
                        data.Name);
                    data.Address = item.Address;
                   
                    data.LocationCode = item.LocationCode;
                    data.LocationName = item.LocationName;
                    data.TypeCode = item.TypeCode;
                    data.Words = item.Words;
                    await DbService.InstitutionService.SyncUpdate();
                }
            }
        }
        private async void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenTool.ShowSplashScreen(this, typeof(SaveBaseDataWaitForm));
            SplashScreenTool.SendCommand(SaveBaseDataWaitForm.WaitFormCommand.SetCaption, "保存进度");
            await SaveBase();
            SplashScreenTool.CloseSplashScreen();

        }
    }
}