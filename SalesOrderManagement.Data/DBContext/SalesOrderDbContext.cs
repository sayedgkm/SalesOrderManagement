using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Data.DBContext
{
    public class SalesOrderDbContext : DbContext
    {
        public SalesOrderDbContext(DbContextOptions<SalesOrderDbContext> options)
            : base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Window> Window { get; set; }
        public DbSet<SubElement> SubElement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Order>()
                    .HasMany<Window>(o => o.Windows)
                    .WithOne(w => w.Order)
                    .HasForeignKey(w => w.OrderId);

            modelBuilder.Entity<Window>()
                    .HasMany<SubElement>(w => w.SubElements)
                    .WithOne(s => s.Window)
                    .HasForeignKey(s=> s.WindowId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
