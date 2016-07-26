﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Mapping.DbModel
{
    [Table("Institutions")]
    public class Institution
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TypeCode { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}