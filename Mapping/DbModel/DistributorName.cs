using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.DbModel
{
    [Table("新库经销商带别名")]
    public class DistributorName
    {
        [Key]
        public Guid Id { get; set; }
        public string DistributorId { get; set; }
        public string UsedName { get; set; }
    }
}
