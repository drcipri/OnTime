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


        /// <summary>
        /// Filter Appointments table.This method eager load all related objects!
        /// Return all objects if no classification is specified!
        /// </summary>
        /// <param name="classification"></param>
        /// <returns>IEnumerable of type Appointment</returns>
        public IEnumerable<Appointment> FilterAppointments(string? classification)
        {
           return  _context.Appointments.Where(c => c.Classification == null || c.Classification.Name == classification)
                                                 .Include(c => c.Classification)
                                                 .OrderBy(c => c.Id);
        }
    }
}
