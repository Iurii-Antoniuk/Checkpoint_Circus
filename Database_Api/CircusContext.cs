using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Database_Api
{
    public class CircusContext : DbContext
    {
        public DbSet<KungfuMastery> KungfuMasteries { get; set; }
        public DbSet<SpiritAnimal> SpiritAnimals { get; set; }
        public DbSet<Tamer> Tamers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=KungfuCircus;Integrated Security=True; MultipleActiveResultSets=True");
        }
    }
}
