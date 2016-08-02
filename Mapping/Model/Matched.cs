using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.Model
{
    public class Matched
    {
        public Item Item { get; set; }
        public List<MatchedInstitutionModel> MatchedInstitutionModels { get; set; }
        public MatchedInstitutionModel MatchedInstitutionModel => MatchedInstitutionModels.FirstOrDefault();
    }
    public class MatchedInstitutionModel : InstitutionModel
    {
        public decimal Percent { get; set; }
        public string PercentStr => (Percent*100).ToString("F2") + "%";
    }
}
