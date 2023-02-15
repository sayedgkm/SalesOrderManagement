using Microsoft.EntityFrameworkCore;
using SalesOrderManagement.Core.Domain;
using SalesOrderManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManagement.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Name = "New York Building 1",
                    State = "NY",
                    CreatedOn = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Name = "California Hotel AJK",
                    State = "CA",
                    CreatedOn = DateTime.Now
                }
            );

            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 1, OrderId = 1, Name = "A51", Quantity = 4 },
                new Window { Id = 2, OrderId = 1, Name = "C Zone 5", Quantity = 2},
                new Window { Id = 3, OrderId = 2, Name = "GLB", Quantity = 3 },
                new Window { Id = 4, OrderId = 2, Name = "OHF", Quantity = 10 }
            );

            modelBuilder.Entity<SubElement>().HasData(
                new SubElement { Id = 1, ElementType = SubElementType.Door, Width=1200, Height = 1850, WindowId = 1},
                new SubElement { Id = 2, ElementType = SubElementType.Window, Width = 800, Height = 1850, WindowId = 1 },
                new SubElement { Id = 3, ElementType = SubElementType.Window, Width = 700, Height = 1850, WindowId = 1 },
                new SubElement { Id = 4, ElementType = SubElementType.Window, Width = 1500, Height = 2000, WindowId = 2 },

                new SubElement { Id = 5, ElementType = SubElementType.Door, Width = 1400, Height = 2200, WindowId = 3 },
                new SubElement { Id = 6, ElementType = SubElementType.Window, Width = 600, Height = 2200, WindowId = 3 },
                new SubElement { Id = 7, ElementType = SubElementType.Window, Width = 1500, Height = 2000, WindowId = 4 },
                new SubElement { Id = 8, ElementType = SubElementType.Window, Width = 1500, Height = 2000, WindowId = 4 }
             );

        }
    }
}
