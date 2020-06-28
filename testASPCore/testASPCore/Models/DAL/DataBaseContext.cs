using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testASPCore.Models.DAL.Entity;

namespace testASPCore.Models.DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conStr = "Server=(localdb)\\mssqllocaldb;Database=test_ASPCore;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(conStr);
        }
    }
}
