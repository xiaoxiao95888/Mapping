using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping.DbModel;

namespace Mapping.Service
{
    public class InstitutionService
    {
        private MappingDbContext DbContext { get; set; }
        public InstitutionService()
        {
            DbContext= new MappingDbContext();
        }

        public IQueryable<Institution> GetAll()
        {
            return DbContext.Institutions;
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
