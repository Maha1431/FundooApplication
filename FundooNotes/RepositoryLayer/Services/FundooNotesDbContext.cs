using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.Notes;


namespace RepositoryLayer.Services
{
   public class FundooNotesDbContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Notes> notes { get; set; }

        public FundooNotesDbContext(DbContextOptions db) : base(db)
        {

        }
      

        protected override void
        
       OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.email)
            .IsUnique();
            modelBuilder.Entity<Notes>()
             .HasOne(u => u.User)
             .WithMany()
             .HasForeignKey(u => u.userId);
            
        }
       

       
    }
}
