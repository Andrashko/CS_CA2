using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6.Models
{
    public class AppDbContext: DbContext
    {
        protected string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\csCa2\lab5\Lab5\CA2_Andrashko.mdf;Integrated Security=True";
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //якщо ім'я таблиці не відповідає моделі
            modelBuilder.Entity<Employee>().ToTable("clinic_employee");
            modelBuilder.Entity<Appointment>().ToTable("appointment");
            //звязок між таблицями
            modelBuilder.Entity<Appointment>()
                .HasOne(appointment => appointment.ClinicEmployee)  // Indicates ChildEntity has one ParentEntity
                .WithMany(employee => employee.Appointments)  // Indicates ParentEntity has many ChildEntities
                .HasForeignKey(appointment => appointment.ClinicEmployeeId);
        }

    }
}
