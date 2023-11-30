using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class EmployeeRepository: IRepository<Employee>
    {
        protected SqlConnection _connection;
        public EmployeeRepository(SqlConnection connection) {
            _connection = connection;
        }
        public List<Employee> GetAll() {
            var employees = new List<Employee>();
            string query = "SELECT * FROM clinic_employee";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee();

                        emp.Id = Convert.ToInt32((reader["Id"]));
                        emp.FullName = Convert.ToString( reader["FullName"]);
                        emp.Speciality = Convert.ToString(reader["Speciality"]);
                        employees.Add( emp );
                    }
                }
            }
                return employees; 
        }

        public List<Employee> GetByName(string name) 
        {
            var employees = new List<Employee>();   
            string querty = $"SELECT * FROM clinic_employee WHERE FullName LIKE '{name}%';";
            using (SqlCommand command = new SqlCommand(querty, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FullName = Convert.ToString(reader["FullName"]),
                            Speciality = Convert.ToString(reader["Speciality"])
                        };
                        employees.Add ( emp );
                    }
                }
            }
            return employees;
        }

        public int UpdateRoom(int from, int to)
        {
            string query = $"UPDATE appointment SET Room = {to} WHERE Room = {from};";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                return command.ExecuteNonQuery();
            }
        }


    }
}
