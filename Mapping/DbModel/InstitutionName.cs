using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.DbModel
{
    [Table("新库医院带别名")]
    public class InstitutionName
    {
        public Guid Id { get; set; }
        public Guid InsId { get; set; }
        [ForeignKey("InsId")]
        public virtual Institution Institution { get; set; }
        public string UsedName { get; set; }

    }
}
