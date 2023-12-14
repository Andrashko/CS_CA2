using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Speciality { get; set; }

       // public ICollection<Appointment>? Appointments { get; set; }
    }
}

