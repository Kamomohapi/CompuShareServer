using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { 
        }

        
        public DbSet<Refubishment> Refubishments { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("password");

            modelBuilder.Entity<Student>().HasData(

                new Student { StudentId = 1, StudentNumber = 102412345, StudentEmail = "102412345@tut4life.ac.za", Name = "Kamohelo", Surname = "Mohapi", Password = hashedPassword },
                new Student { StudentId = 2, StudentNumber = 102423456, StudentEmail = "102423456@tut4life.ac.za", Name = "Thabo", Surname = "Mohale", Password = hashedPassword },
                new Student { StudentId = 3, StudentNumber = 102434567, StudentEmail = "102434567@tut4life.ac.za", Name = "Busisiwe", Surname = "Mkhize", Password = hashedPassword },
                new Student { StudentId = 4, StudentNumber = 102445678, StudentEmail = "102445678@tut4life.ac.za", Name = "Jabulile", Surname = "Mkhwanazi", Password = hashedPassword });



            modelBuilder.Entity<Admin>().HasData(new Admin {Id = 1,Name = "Thabo", Surname = "Khoza", Email = "thabo@gmail.com",Password = hashedPassword },
                                                  new Admin { Id = 2, Name = "Thato", Surname = "Mamatela", Email = "thato@gmail.com",Password = hashedPassword});

        }
    }


 
}
