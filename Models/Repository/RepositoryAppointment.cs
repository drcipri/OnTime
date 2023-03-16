using Microsoft.EntityFrameworkCore;
using OnTime.Models.DatabaseConfigs;
using System.Reflection.Metadata.Ecma335;

namespace OnTime.Models.Repository
{
    public class RepositoryAppointment: IRepositoryAppointment
    {
        private readonly OnTimeAppointmentsDbContext _context;

        public RepositoryAppointment(OnTimeAppointmentsDbContext context)
        {
            _context = context;
        }
        public IQueryable<Appointment> Appointments => _context.Appointments;

    }
}
