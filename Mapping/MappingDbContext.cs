using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapping.DbModel;

namespace Mapping
{
    public class MappingDbContext : DbContext
    {
        private const string Coon = "Data Source=www.smc-sfe.com;Initial Catalog=Mapping;Persist Security Info=True;User ID=sa;Password=XXXboy123";
        public DbSet<Institution> Institutions { get; set; }protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new LetterMapping());
            //modelBuilder.Configurations.Add(new RetailerMapping());
            //modelBuilder.Configurations.Add(new SiteMapping());
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 如果连接字符串传进来的话用这个方法
        /// </summary>
        /// <param name="conStr"></param>
        public MappingDbContext(string conStr) : base(conStr)
        {
        }

        public MappingDbContext() : base(Coon) { }
    }
}
