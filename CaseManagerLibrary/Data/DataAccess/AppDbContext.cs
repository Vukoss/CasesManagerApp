using System.Reflection.Emit;
using CaseManagerLibrary.Models;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Laboratory>().HasKey(u => u.Id);

            builder.Entity<Laboratory>().HasData(
                new Laboratory { Id = 1, LaboratoryName = "Chemia" },
                new Laboratory { Id = 2, LaboratoryName = "Biologia" });

            const string defaultAdminUserName = "admin@admin.pl";
            const string defaultAdminPassword = "Admin.123";
            const string adminRoleName = "Administrator";

            var adminUser = new Specialist
            {
                UserName = defaultAdminUserName,
                NormalizedUserName = defaultAdminUserName.ToUpper(),
                Email = defaultAdminUserName,
                NormalizedEmail = defaultAdminUserName.ToUpper(),
                FirstName = "John",
                LastName = "Doe",
                LaboratoryId = 1,
                EmailConfirmed = true
            };

            var adminRole = new IdentityRole
            {
                Name = adminRoleName,
                NormalizedName = adminRoleName.ToUpper()
            };

            builder.Entity<IdentityRole>().HasData(adminRole);

            var passwordHasher = new PasswordHasher<Specialist>();

            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, defaultAdminPassword);

            builder.Entity<Specialist>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            });

            base.OnModelCreating(builder);
        }
    }
}