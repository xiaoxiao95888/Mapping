using Mapping.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public static class DataSource
    {
        public static BindingList<Item> DataSource1 { get; set; }
        public static BindingList<Item> DataSource2 { get; set; }
        public static Item SelectedItem { get; set; }
        public static Place SelectedPlace { get; set; }
    }
}
