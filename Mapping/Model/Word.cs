using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Model
{
    public class Word
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; }
    }
}
