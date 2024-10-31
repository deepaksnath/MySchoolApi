using Microsoft.EntityFrameworkCore;
using MySchool.Api.Data.Models;
using System.Runtime.CompilerServices;

namespace MySchool.Api.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) 
        { 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Student>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();

            modelBuilder.Entity<Department>()
                    .Property(s => s.Id)
                    .HasColumnName("Id")
                    .IsRequired();
        }
    }
}
