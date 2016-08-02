using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
            DbContext = new MappingDbContext();
        }
        public IQueryable<Institution> GetAll()
        {
            return DbContext.Institutions;
        }
        public BindingList<Institution> GetAllBindingList()
        {
            DbContext.Institutions.Load();
            return DbContext.Institutions.Local.ToBindingList();
        }

        public Institution GetInstitution(Guid id)
        {
            return DbContext.Institutions.FirstOrDefault(n => n.Id == id);
        }
        public void Update()
        {
            DbContext.SaveChanges();
        }
        public async Task SyncUpdate()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
