using System;
using System.Collections;
using System.Data;
using System.Linq;
using DevExpress.Spreadsheet;


namespace Mapping.View
{
    public partial class SheetFormProcessingResult : DevExpress.XtraEditors.XtraForm
    {
        public SheetFormProcessingResult()
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
            var result = DataSource.DataSource1.Select(n => new
            {
                n.Id,
                n.Code,
                n.Name,
                MatchedName =n.Places.Select(p=>p.Name).FirstOrDefault(),
                n.Type,
                n.TypeCode,
                n.Province,
                n.City,
                n.District,
                n.Address,
                n.Words
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