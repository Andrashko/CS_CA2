
using Microsoft.EntityFrameworkCore;

namespace Lab9.Models
{
    public class EmployeeRepositoryAsync : IRepositoryAsync<Employee>

    {
        private AppDbContext _db;
        public EmployeeRepositoryAsync(AppDbContext db) {
            _db = db;
        }
        public async Task<Employee> Create(Employee value)
        {
            var employee = await _db.AddAsync(value);
            await _db.SaveChangesAsync();
            return employee.Entity;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employee> Delete(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(int id, Employee value)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            employee.Speciality = value.Speciality;
            employee.FullName = value.FullName;
            _db.Employees.Entry(employee).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return employee;
        }
    }
}
