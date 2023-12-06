using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class EmployeeRepository
    {
        protected AppDbContext _db;
        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Employee> GetAll()
        {
            return _db.Employees
                .Include(employee => employee.Appointments)
                .ToList();
        }

        public List<Employee> GetByName(string name)
        {
            return _db.Employees
                .Where(employee => employee.FullName.StartsWith(name))
                .Include(employee => employee.Appointments)
                .ToList();
        }

    }
}
