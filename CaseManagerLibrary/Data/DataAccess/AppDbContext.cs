using CaseManagerLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaseManagerLibrary.Data.DataAccess
{
    public class AppDbContext : IdentityDbContext<Specialist>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; User ID=patryk; Port=5432; Database=CasesManagerBlazor; Password=123456;");
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Laboratory>().HasData(
        //         new Laboratory { LaboratoryName = "Laboratorium Daktyloskopijne" },
        //         new Laboratory {LaboratoryName = "Laboratorium Biologiczne"},
        //         new Laboratory {LaboratoryName = "Laboratorium Chemiczne"},
        //         new Laboratory {LaboratoryName = "Laboratorium Dokumentów"}
        //     );
        // }
    }
}