using Client_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Management.DAL
{
    public class Context : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerTypes> CustomerTypes{ get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7VEMDTB;Database=Test_Invoice;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerTypes>().HasData(
                    new CustomerTypes() { Id = 1, Description = "Normal"},
                    new CustomerTypes() { Id = 2, Description = "VIP" }
                );

            modelBuilder.Entity<Customers>().HasData(
                new Customers() { Id = 1, CustName = "Bill gates 2th", Adress = "773 S. Queen St.Nutley, NJ 07110", Status = true, CustomerTypeId = 1 },
                new Customers() { Id = 2, CustName = "Juan Perez 2th", Adress = "64 Blue Spring Street Bonita Springs, FL 34135", Status = true, CustomerTypeId = 2 }
                );
        }
    }

}
