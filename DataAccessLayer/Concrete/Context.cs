using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory).UseMySql(@"server=localhost;port=3306;database=Oasis;user=root;password=yasar11@;",ServerVersion.AutoDetect(@"server=localhost;port=3306;database=Oasis;user=root;password=yasar11@;"), null);
            //.UseSqlServer("Server=LAPTOP-T6B561GB;Database=Oasis;User Id=sa;Password=forAlly;");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<CreditCard> creditCards { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Invoice> invoices { get; set; }
    }
}
