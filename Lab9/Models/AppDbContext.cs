using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9.Models
{
    public class AppDbContext : DbContext
    {
        protected string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\csCa2\lab5\Lab5\CA2_Andrashko.mdf;Integrated Security=True";
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //якщо ім'я таблиці не відповідає моделі
            modelBuilder.Entity<Employee>().ToTable("clinic_employee");
        }

    }
}
