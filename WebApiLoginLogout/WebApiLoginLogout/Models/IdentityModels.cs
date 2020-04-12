using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiLoginLogout.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FullName { get; set; }
        
    }

    public class ApplicationUserDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserDbContext():base("DefaultConnection",throwIfV1Schema:false)
        {
                
        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");

        }
    }
}