using lab6.Models;



using (var db = new AppDbContext())
{
    var employeeRepo = new EmployeeRepository(db);
    var appointmentRepo = new AppointmentRepository(db);
   
    Console.Write("Enter name to search:");
    string searchName = Console.ReadLine();
    var employees = employeeRepo.GetByName(searchName);
    foreach (Employee employee in employees)
    {
        Console.WriteLine($"{employee.FullName} ({employee.Speciality})");
    }

    Console.Write("Enter room to change:");
    int from  = int.Parse(Console.ReadLine());
    Console.Write("Enter new room to change:");
    int to = int.Parse(Console.ReadLine());
    Console.WriteLine($"{appointmentRepo.UpdateRoom(from,to)} room were updated");

    var appointmentRepoAsync = new AppointmentRepositoryAsync(db);
    Console.WriteLine($"{await appointmentRepoAsync.UpdateRoom(from, to)} room were updated");

    var appointments = await appointmentRepoAsync.GetAll();
    foreach (Appointment appointment in appointments)
    {
        Console.WriteLine($"{appointment.Room}: ({appointment.StartTime}-{appointment.EndTime})");
    }

}
