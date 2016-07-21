using LinqToExcel;
using System.Collections.Generic;
using System.Linq;

namespace Mapping.Helper
{
    public static class ExcelHelper
    {
        public static IEnumerable<T> GetDataFromExcel<T>(string filePath)
        {
            var excel = new ExcelQueryFactory(filePath);
            var result = excel.Worksheet<T>().ToList();
            return result;
        }
    }
}
