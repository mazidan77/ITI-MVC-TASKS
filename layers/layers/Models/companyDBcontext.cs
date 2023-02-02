using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
namespace layers.Models
{
    public class companyDBcontext:IdentityDbContext


  
    {
        public companyDBcontext()
        {

        }
        public companyDBcontext(DbContextOptions options) : base(options) 
        {

        }

        public virtual DbSet<employee> employees { get; set; }
         public virtual DbSet<department> Departments { get; set; } 

        public virtual DbSet<dependent> Dependents { get; set; }

        public virtual DbSet<Dlocations> DLocations { get; set; }
        public virtual DbSet<project> Projects { get; set; }

        public virtual DbSet<workfor> WorksFor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=ZIDAN\\SQLEXPRESS;Initial Catalog=ident;Integrated Security=True ;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<workfor>().HasKey("ESSN", "Pnum");
            modelBuilder.Entity<dependent>().HasKey("name", "EmployeeSSN");
            modelBuilder.Entity<Dlocations>().HasKey("Dlocation", "Dnum");



            modelBuilder.Entity<department>(entity =>
            {

                modelBuilder.Entity<department>().HasOne(e => e.Employee).WithOne(d => d.ManageDepartment);
                modelBuilder.Entity<department>().HasMany(e => e.Employees).WithOne(d => d.WorkDepartment);
            });
        }

    }
}
