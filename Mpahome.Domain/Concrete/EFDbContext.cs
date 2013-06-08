using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mpahome.Domain.Entities;
using System.Data.Entity;

namespace Mpahome.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<OAuthMembership> OAuthMemberships { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasMany(u => u.Roles)
           .WithMany(r => r.Users)
           .Map(m =>
           {
               m.ToTable("webpages_UsersInRoles");
               m.MapLeftKey("UserId");
               m.MapRightKey("RoleId");
           });
            modelBuilder.Entity<OAuthMembership>().HasKey(m => new { m.Provider, m.ProviderUserId });
        }
    }

    public class EFDbContextContextInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var roles = new List<Role>{
                new Role{RoleName = "Administrator"},
                new Role{RoleName = "User"}               
            };
            roles.ForEach(r => context.Roles.Add(r));
        }
    }
}
