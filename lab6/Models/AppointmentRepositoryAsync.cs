using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class AppointmentRepositoryAsync
    {
        protected AppDbContext _db;
        public AppointmentRepositoryAsync(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _db.Appointments.ToListAsync();
        }
        public async Task<int> UpdateRoom(int from, int to)
        {
           (await _db.Appointments
                .Where(appointment => appointment.Room == from)
                .ToListAsync())
                .ForEach(appointment => appointment.Room = to);
            return await _db.SaveChangesAsync();
        }
    }
}
