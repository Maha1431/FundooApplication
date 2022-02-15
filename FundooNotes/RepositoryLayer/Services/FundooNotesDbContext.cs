using RepositoryLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace RepositoryLayer.Services
{
    public class FundooNotesDbContext : DbContext
    {


        public FundooNotesDbContext(DbContextOptions db) : base(db)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Notes> notes { get; set; }

        protected override void

       OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasIndex(u => u.email)
            .IsUnique();
            //modelBuilder.Entity<Note>()
            //.HasOne(u => u.User)
            //.WithMany()
            //.HasForeignKey(u => u.userId);
        }




    }



}

