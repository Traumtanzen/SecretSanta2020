using Microsoft.EntityFrameworkCore;
using SecretSanta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gifter> Gifters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DELL-SERGEY;Database=SecretSantaDb;Integrated Security=True;");
        }
    }
}
