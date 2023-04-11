using Deneme.Authorization.Nuget.Model.Entity;
using Microsoft.EntityFrameworkCore;
using SOD.Model;

namespace SOD.Data
{
    public class SampleProjectDbContext : DbContext
    {
        public SampleProjectDbContext(DbContextOptions<SampleProjectDbContext> contextOptions) : base(contextOptions)
        {

        }

         public DbSet<StudentEntity> StudentEntities { get; set; }
         public DbSet<PersonnelEntity> PersonnelEntities { get; set; }
        public DbSet<RoleEntity> RoleEntities { get; set; }
        public DbSet<RolePrivilegeEntity> RolePrivilegeEntities { get; set; }
        public DbSet<PrivilegeEntity> PrivilegeEntities { get; set; }
        public DbSet<PersonnelRoleEntity> PersonnelRoleEntities { get; set; }
    }
}
