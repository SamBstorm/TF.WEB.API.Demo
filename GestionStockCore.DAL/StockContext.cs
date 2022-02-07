using GestionStockCore.DAL.Entities;
using GestionStockCore.DAL.Enums;
using GestionStockCore.DAL.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStockCore.DAL
{
    public class StockContext : DbContext
    {
        public StockContext()
        {
        }

        public StockContext(DbContextOptions option)
            : base(option)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<VOrder> VOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(_products);
            builder.Entity<Customer>().HasData(_customers);
            builder.Entity<Order>().HasData(_orders);
            builder.Entity<OrderLine>().HasData(_ordersLines);
            builder.Entity<VOrder>().ToView("VOrders").HasNoKey();
        }

        private IEnumerable<Product> _products = new[]
        {
            new Product { Reference = "COCA0001", Name = "Coca Cola 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 },
            new Product { Reference = "COCA0002", Name = "Coca Cola 50cl", Description = "CAN. 24X50cl", Price = 19.92m, Stock = 1000 },
            new Product { Reference = "COCA0003", Name = "Coca Cola 1l", Description = "BOUT. 6X1l", Price = 10.92m, Stock = 1000 },
            new Product { Reference = "FANT0001", Name = "Fanta Orange 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 },
            new Product { Reference = "FANT0002", Name = "Fanta Citron 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 },
            new Product { Reference = "FANT0003", Name = "Fanta Orange 50cl", Description = "CAN. 24X50cl", Price = 16.8m, Stock = 1000 },
            new Product { Reference = "FANT0004", Name = "Fanta Citron 50cl", Description = "CAN. 24X50cl", Price = 19.92m, Stock = 1000 },
            new Product { Reference = "JUPI0001", Name = "Jupiler 33cl", Description = "CAN. 24X33cl", Price = 29.04m, Stock = 1000 },
            new Product { Reference = "JUPI0002", Name = "Jupiler 50cl", Description = "CAN. 24X50cl", Price = 35.52m, Stock = 1000 },
            new Product { Reference = "CARL0001", Name = "Carlsberg 33cl", Description = "CAN. 24X33cl", Price = 32.4m, Stock = 1000 },
            new Product { Reference = "CHIM0001", Name = "Chimay Bleue 33cl", Description = "BOUT. 24X33cl", Price = 45.6m, Stock = 1000 },
            new Product { Reference = "CHIM0002", Name = "Chimay Rouge 33cl", Description = "BOUT. 24X33cl", Price = 45.6m, Stock = 1000 },
            new Product { Reference = "CHIM0003", Name = "Chimay Blanche 33cl", Description = "BOUT. 24X33cl", Price = 30.24m, Stock = 1000 },
            new Product { Reference = "NALU0001", Name = "Nalu Vert 25cl", Description = "CAN. 24X25cl", Price = 16.8m, Stock = 1000 },
            new Product { Reference = "EVIA0001", Name = "Evian 1l", Description = "BOUT. 8X1l", Price = 8.96m, Stock = 1000 },
            new Product { Reference = "EVIA0002", Name = "Evian 50cl", Description = "BOUT. 24X50cl", Price = 5.6m, Stock = 1000 },
            new Product { Reference = "VITT0001", Name = "Vittel 1l", Description = "BOUT. 8X1l", Price = 8.72m, Stock = 1000 },
            new Product { Reference = "VITT0002", Name = "Vittel 50cl", Description = "BOUT. 24X50cl", Price = 5.44m, Stock = 1000 },
            new Product { Reference = "OASI0001", Name = "Oasis Orange 2l", Description = "BOUT. 6X2l", Price = 13.44m, Stock = 1000 },
            new Product { Reference = "OASI0002", Name = "Oasis Tropical 2l", Description = "BOUT. 6X2l", Price = 13.44m, Stock = 1000 },

        };

        private IEnumerable<Customer> _customers = new[]
        {
            new Customer
            {
                Reference = "LYKH0001",
                LastName = "Ly",
                FirstName = "Khun",
                Email = "lykhun@gmail.com"
            },
            new Customer { Reference = "LYPI0001", LastName = "Ly", FirstName = "Piv", Email = "piv.ly@bstorm.be" },
            new Customer { Reference = "PEMI0001", LastName = "Person", FirstName = "Mike", Email = "michael.person@cognitic.be" },
            new Customer { Reference = "MOTH0001", LastName = "Morre", FirstName = "Thierry", Email = "tierry.morre@cognitic.be" },
            new Customer { Reference = "COJU0001", LastName = "Coppin", FirstName = "Julien", Email = "julien.coppin@bstorm.be" },
            new Customer { Reference = "COJU0002", LastName = "Courtois", FirstName = "Julie", Email = "julie@courtois.be" },
            new Customer { Reference = "STAU0001", LastName = "Strimelle", FirstName = "Aurélien", Email = "aurelien.strimelle@bstorm.be" },
            new Customer { Reference = "OVFL0001", LastName = "Ovyn", FirstName = "Flavian", Email = "flavian.ovyn@bstorm.be" },
            new Customer { Reference = "LAST0001", LastName = "Laurent", FirstName = "Steve", Email = "steve.laurent@bstorm.be" },
            new Customer { Reference = "BALO0001", LastName = "Baudoux", FirstName = "Loïc", Email = "loic.baudoux@bstorm.be" },
            new Customer { Reference = "PEMI0002", LastName = "Pedro", FirstName = "Michel", Email = "michel@pedro.be" },
            new Customer { Reference = "COJU0003", LastName = "Constant", FirstName = "Jules", Email = "jules@constant.be" },
        };

        private IEnumerable<Order> _orders = new[] {
             new Order { Reference = new DateTime(2022,1,31).ToString("yyMMdd") + "0001", UpdateDate = new DateTime(2022,1,31), Status = OrderStatus.InProgress, CustomerRef = "MOTH0001" },
             new Order { Reference = new DateTime(2022,1,31).ToString("yyMMdd") + "0002", UpdateDate = new DateTime(2022,1,31).AddMinutes(50), Status = OrderStatus.Canceled, CustomerRef = "PEMI0001" },
             new Order { Reference = new DateTime(2022,1,31).ToString("yyMMdd") + "0003", UpdateDate = new DateTime(2022,1,31).AddMinutes(242), Status = OrderStatus.Closed, CustomerRef = "COJU0001" },
             new Order { Reference = new DateTime(2022,1,31).ToString("yyMMdd") + "0004", UpdateDate = new DateTime(2022,1,31).AddMinutes(300), Status = OrderStatus.Pending, CustomerRef = "COJU0001" },
        };

        private IEnumerable<OrderLine> _ordersLines = new[] {
             new OrderLine { Id = 1, OrderRef = new DateTime(2022,1,31).ToString("yyMMdd") + "0001", ProductRef = "COCA0001", Quantity = 50 },
             new OrderLine { Id = 2, OrderRef = new DateTime(2022,1,31).ToString("yyMMdd") + "0002", ProductRef = "JUPI0001", Quantity = 10 },
             new OrderLine { Id = 3, OrderRef = new DateTime(2022,1,31).ToString("yyMMdd") + "0003", ProductRef = "COCA0002", Quantity = 100, UnitPrice = 19.92M },
             new OrderLine { Id = 4, OrderRef = new DateTime(2022,1,31).ToString("yyMMdd") + "0004", ProductRef = "FANT0002", Quantity = 25, UnitPrice = 16.24M },
             new OrderLine { Id = 5, OrderRef = new DateTime(2022,1,31).ToString("yyMMdd") + "0004", ProductRef = "COCA0001", Quantity = 20, UnitPrice = 16.24M },
        };
    }
}
