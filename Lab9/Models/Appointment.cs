using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int? Day { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public int? Room { get; set; }
        public string? Department { get; set; }

        public int? ClinicEmployeeId { get; set; }
        public Employee? ClinicEmployee { get; set; }

    }
}
