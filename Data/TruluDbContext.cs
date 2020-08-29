using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trululu.web.Entities;

namespace Trululu.web.Data
{
    public class TruluDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Casting> Castings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=trululu.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Casting>().ToTable("casting");
        }
    }
}

