using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Model
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// 地理信息
        /// </summary>
        public List<Place> Places { get; set; }
        /// <summary>
        /// 分词
        /// </summary>
        public string Words { get; set; }
        public string[] JoinWords => string.IsNullOrEmpty(Words) ? null : Words.Split(',');
        public int PlaceCount => Places.Count;
        

    }
}
