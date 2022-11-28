using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectAPI.Models
{
    public class VipContext : DbContext
    {
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Trips> Trips { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Sales> Sales { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SqlServer;Database=kawaKohatsuDb;User Id=sa;password=system@123");
        }
    }
}
