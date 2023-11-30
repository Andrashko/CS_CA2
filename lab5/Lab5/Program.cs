/* CRUD
Create
Read
Update 
Delete
*/

using Lab5.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace Lab5
{
    class Program
    {
        public static void Main()
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\csCa2\lab5\Lab5\CA2_Andrashko.mdf;Integrated Security=True";
            using( SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var rep = new EmployeeRepository(connection);

                Console.Write("Enter room to change");
                int from = int.Parse(Console.ReadLine());
                Console.Write("New room");
                int to = int.Parse(Console.ReadLine());
                int count  = rep.UpdateRoom(from, to);
                Console.WriteLine($" {count} room were updated");


               
                var employees = rep.GetAll();
                Console.WriteLine("All employees");
                foreach(  Employee employee in employees )
                {
                    Console.WriteLine($"{employee.FullName}");
                }

                Console.Write("Enter name to search:");
                string searchName = Console.ReadLine();
                employees = rep.GetByName(searchName);
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"{employee.FullName} ({employee.Speciality})");
                }

                /*
                 * SELECT * FROM clinic_employee WHERE FullName LIKE 'Var%';
                 
                Console.Write("Enter name to search:");
                string searchName = Console.ReadLine();
                string querty = $"SELECT * FROM clinic_employee WHERE FullName LIKE '{searchName}%';";
                using (SqlCommand command = new SqlCommand(querty, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Console.WriteLine( $"Full name: { reader["FullName"]}");
                            Console.WriteLine($"Speciality: {reader["Speciality"]}");
                        }
                    }
                }
                */


                Console.Write("Enter day number 1-mondey, 2-tuesday...: ");
                int day = int.Parse( Console.ReadLine() );
                string queryA = $"SELECT  clinic_employee.FullName, appointment.Room, appointment.Day FROM clinic_employee INNER JOIN appointment ON clinic_employee.Id = appointment.ClinicEmployeeId WHERE appointment.Day = {day};";
                using (SqlCommand command = new SqlCommand(queryA, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Full name: {reader["FullName"]}");
                            Console.WriteLine($"Room: {reader["Room"]}");
                        }
                   }
                }
            }
            Console.WriteLine("");
        }
    }
}