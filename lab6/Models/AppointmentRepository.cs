using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class AppointmentRepository
    {
        protected AppDbContext _db;
        public AppointmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Appointment> GetAll()
        {
            return _db.Appointments.ToList();
        }
        public int UpdateRoom(int from, int to)
        {
            _db.Appointments
                .Where(appointment => appointment.Room == from)
                .ToList()
                .ForEach(appointment => appointment.Room = to);
            return _db.SaveChanges();
        }
    }
}
