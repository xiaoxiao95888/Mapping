using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Model
{
    public class Place
    {
        public string Id { get; set; }
        public Guid ItemId { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }
       
    }
  
}
