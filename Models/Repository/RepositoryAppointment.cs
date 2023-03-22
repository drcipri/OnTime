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

        public void AddAppointment(Appointment appointment)
        {
            _context.Add(appointment);
            _context.SaveChanges();
        }
        public void RemoveById(int id)
        {
            Appointment? apToRemove = _context.Appointments.FirstOrDefault(c => c.Id == id);
            if (apToRemove != null)
            {
                _context.Remove(apToRemove);
                _context.SaveChanges();
            }

        }
        public void UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }
        public Appointment? GetAppointment(int id)
        {
            return _context.Appointments.Include(c => c.Classification).FirstOrDefault(c => c.Id == id);
        }
        /// <summary>
        /// Change classification if the appointment is found
        /// </summary>
        /// <param name="id">Appointment id</param>
        /// <param name="classificationName">Classification Name</param>
        public void MarkAppointment(int id, string classificationName)
        {
            Appointment? apToRemove = _context.Appointments.FirstOrDefault(c => c.Id == id);
            if(apToRemove != null)
            {
                apToRemove.ClassificationId = _context.Classifications.First(c => c.Name == classificationName).Id;
                _context.SaveChanges();
            }
        }


        /// <summary>
        /// Filter Appointments table.This method eager load all related objects!
        /// Return all objects order by id!
        /// If no classification is specified all data will be returned!
        ///
        /// </summary>
        /// <param name="classification"></param>
        /// <returns>IEnumerable of type Appointment</returns>
        public IEnumerable<Appointment> FilterAppointments(string? classification)
        {
            return _context.Appointments.Where(c => c.Classification == null || c.Classification.Name == classification)
                                                  .Include(c => c.Classification)
                                                  .OrderBy(c => c.Id);
        }

        
    }
}
