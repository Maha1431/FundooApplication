using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
   public class FundooNotesDbContext:DbContext
    {
        public FundooNotesDbContext(DbContextOptions db) : base(db)
        {

        }
        public DbSet<User> users { get; set; }
        protected override void
        
       OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.email)
            .IsUnique();
        }

    }
}
