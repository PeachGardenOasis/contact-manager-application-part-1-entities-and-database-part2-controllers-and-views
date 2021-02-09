using Microsoft.EntityFrameworkCore; // needed for extend dbcontext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Contact_Manager_Application.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options) // generics allow you to write a class or method that can work with any data type.
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categeories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // onmodelcreating construct and seeds the contactmanager database
        {
            modelBuilder.Entity<Category>().HasData( // populate modelbuilder entitity category
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
        );
            modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ContactId = 1,
                        Firstname = "Bruce",
                        Lastname = "Wayne",
                        Phone = "416-123-4567",
                        Email = "bruce.wayne@domain.com",
                        CategoryId = 1,
                        DateAdded = DateTime.Now
                    },

                    new Contact
                    {
                        ContactId = 2,
                        Firstname = "Peter",
                        Lastname = "Parker",
                        Phone = "647-123-4567",
                        Email = "peter.parker@isp.com",
                        CategoryId = 2,
                        DateAdded = DateTime.Now
                    },
                    new Contact
                    {
                        ContactId = 3,
                        Firstname = "Diana",
                        Lastname = "Prince",
                        Phone = "647-123-4567",
                        Email = "diana.prince@gbc.com",
                        CategoryId = 3,
                        DateAdded = DateTime.Now
                    }
    
              );

        }
    }
}