using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiLoginLogout.Migrations;

namespace WebApiLoginLogout.Models
{
    [Table("Annonce")]
    public class Annonce
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ContenuAnnonce { get; set; }
        public DateTime? DateAnnonce { get; set; }

    }
    public class AnnonceDbContext: DbContext
    {
        public AnnonceDbContext():base("DefaultConnection")
        {

        }
        public DbSet<Annonce> Annonces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Annonce>().ToTable("Annonce");
            
        }
    }
    
}