﻿using Microsoft.EntityFrameworkCore;
using UnitOfWork.Models;

namespace UnitOfWork.DataContext
{
    public class AppDbContext : DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }




        public DbSet<Category> Categories { get; set; }
        public  DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            // Products
            mb.Entity<Product>().Property(p => p.Name)
                                .IsRequired()
                                .HasMaxLength(30);
                                        
            mb.Entity<Product>().Property(p => p.Description)
                               .IsRequired()
                               .HasMaxLength(200);

            mb.Entity<Product>().Property(p => p.Price)
                                .IsRequired()
                                .HasColumnType("decimal");

            mb.Entity<Product>().Property(p => p.Quantity)
                                .HasColumnType("int");
           

            //Catogories
            mb.Entity<Category>().Property(c => c.Name)
                                 .IsRequired().
                                 HasMaxLength(30);

            mb.Entity<Category>().Property(c => c.Description)
                                 .IsRequired()
                                 .HasMaxLength (200);


            //Reletionships

            mb.Entity<Product>().HasOne<Category>(c => c.Category)
                .WithMany(m => m.Products)
                .HasForeignKey(c => c.Id);

        }
    }
}

