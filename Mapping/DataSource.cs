using Mapping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping.DbModel;
using Mapping.Service;

namespace Mapping
{
    public static class DataSource
    {
        public static BindingList<Item> DataSource1 { get; set; }
        /// <summary>
        /// 主数据
        /// </summary>
        public static List<Institution> Institutions { get; set; }
        public static Item SelectedItem { get; set; }
        public static Place SelectedPlace { get; set; }
    }

    public static class DbService
    {
        public static InstitutionService InstitutionService { get; set; }
    }
}
