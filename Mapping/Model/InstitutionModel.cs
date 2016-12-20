using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Model
{
    public class InstitutionModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Address { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public string Province
        {
            get
            {
                var str = LocationName?.Split(' ').FirstOrDefault();
                return str;
            }
        }

        public string City
        {
            get
            {
                var arr = LocationName?.Split(' ');
                if (arr != null && arr.Length >= 2)
                {
                    return arr[1];
                }
                return null;
            }
        }
        public string District
        {
            get
            {
                var arr = LocationName?.Split(' ');
                if (arr != null && arr.Length >= 3)
                {
                    return arr[2];
                }
                return null;
            }
        }
        public string Words { get; set; }
        public DateTime UpdateTime { get; set; }
        public string[] JoinWords => string.IsNullOrEmpty(Words) ? null : Words.Split(',');
        public List<string> UsedNames { get; set; }

    }
}
