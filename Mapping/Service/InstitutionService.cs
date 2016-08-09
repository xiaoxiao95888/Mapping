using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping.DbModel;
using Mapping.Model;

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
            return DbContext.Institutions.Take(100);
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
        /// <summary>
        /// 暂时直接保存分词
        /// </summary>
        /// <param name="model"></param>
        public void UpdateParticiple(InstitutionModel model)
        {
            var count =
                DbContext.Database.SqlQuery<Guid>(string.Format("select Id from [Participle] where ObjectId='{0}'",
                    model.Id)).ToList();
            if (count.Any())
            {
                DbContext.Database.ExecuteSqlCommand(string.Format("update [Participle]  set Words='{0}' where ObjectId='{1}'",
                    model.Words, model.Id));
            }
            else
            {
                DbContext.Database.ExecuteSqlCommand(
                    string.Format("INSERT INTO [Participle] values(NEWID(),'{0}','{1}')" ,model.Id, model.Words));
            }

        }
    }
}
