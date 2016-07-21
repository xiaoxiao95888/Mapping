using System;
using System.Collections.Generic;
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
        /// <summary>
        /// 分词
        /// </summary>
        public Word[] Words { get; set; }
        /// <summary>
        /// 地理信息
        /// </summary>
        public Place[] Place { get; set; }
    }
}
