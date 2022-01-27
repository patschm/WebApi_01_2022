using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonHobby>().HasKey(ph=>new {ph.PersonId, ph.HobbyId});
            modelBuilder.Entity<Hobby>().Property(h=>h.Name).HasMaxLength(255).IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
    }
}