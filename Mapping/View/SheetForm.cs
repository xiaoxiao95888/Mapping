using System;
using System.Collections;
using System.Data;
using System.Linq;
using DevExpress.Spreadsheet;


namespace Mapping.View
{
    public partial class SheetForm : DevExpress.XtraEditors.XtraForm
    {
        public SheetForm()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            //spreadsheetControl1.BeginUpdate();
            var worksheet = spreadsheetControl1.Document.Worksheets[0];
            var table = GetTable();
            worksheet.Import(table, true,0,0);
            worksheet.Columns.AutoFit(0, table.Columns.Count);
            //spreadsheetControl1.EndUpdate();
        }

        private DataTable GetTable()
        {
            var dt = new DataTable();
            var result = DataSource.Matcheds.Select(n => new
            {
                Code = n.Item.Code,
                Name = n.Item.Name,
                Province = n.Item.Province,
                City = n.Item.City,
                District = n.Item.District,
                Industry = n.Item.Type,
                IndustryCode = n.Item.TypeCode,
                //Words = n.Item.Words,
                _Id = n.MatchedInstitutionModel?.Id.ToString(),
                _Name = n.MatchedInstitutionModel?.Name,
                _Province = n.MatchedInstitutionModel?.Province,
                _City = n.MatchedInstitutionModel?.City,
                _District = n.MatchedInstitutionModel?.District,
                _Industry = n.MatchedInstitutionModel?.Type,
                _IndustryCode = n.MatchedInstitutionModel?.TypeCode,
                //_Words = n.MatchedInstitutionModel?.Words,
                Weight = n.MatchedInstitutionModel?.PercentStr,
            }).ToList();
            if (result.Any())
            {
                //通过反射获取list中的字段 
                var p = result[0].GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo pi in p)
                {
                    //Type.GetType(pi.PropertyType.ToString()
                    dt.Columns.Add(pi.Name, typeof (String));
                }
                foreach (var t in result)
                {
                    IList tempList = new ArrayList();
                    //将IList中的一条记录写入ArrayList
                    foreach (System.Reflection.PropertyInfo pi in p)
                    {
                        var oo = pi.GetValue(t, null);
                        tempList.Add(oo);
                    }
                    var itm = new object[p.Length];
                    for (var j = 0; j < tempList.Count; j++)
                    {
                        itm.SetValue(tempList[j], j);
                    }
                    dt.LoadDataRow(itm, true);
                }
            }
            return dt;
        }
    }
}