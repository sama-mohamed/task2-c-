using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1_ef_eraasoft.models;

namespace task1_ef_eraasoft.data
{
    internal class Application_DBContext: DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<Sale> sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFTask1;Integrated Security=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Customer>()
               .Property(e => e.Email)
               .HasColumnType("varchar(80)");

            modelBuilder.Entity<Store>()
               .Property(e => e.name)
               .HasColumnType("varchar(80)");

        }
    }
}
