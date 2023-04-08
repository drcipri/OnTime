using Microsoft.EntityFrameworkCore;
using OnTime.Models.DatabaseConfigs;
using OnTime.ViewModels;
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

        /// <summary>
        /// If found, removes the appointment by id and returns true , otherwise false.
        /// </summary>
        /// <param name="id"></param>
        public bool RemoveById(int id)
        {
            Appointment? apToRemove = _context.Appointments.FirstOrDefault(c => c.Id == id);
            if (apToRemove != null)
            {
                _context.Remove(apToRemove);
                _context.SaveChanges();
                return true;
            }
            return false;
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
        public bool MarkAppointment(int id, string classificationName)
        {
            Appointment? apToMark = _context.Appointments.FirstOrDefault(c => c.Id == id);
            if(apToMark != null)
            {
                Classification? classification = _context.Classifications.FirstOrDefault(c => c.Name == classificationName);
                if (classification != null)
                {
                    apToMark.ClassificationId = classification.Id;
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Filter Appointments table.This method eager load all related objects!
        /// Return all objects order by id!
        /// If no classification is specified all data will be returned!
        ///
        /// </summary>
        /// <param name="classification"></param>
        /// <returns>IEnumerable of type Appointment</returns>
        public async IAsyncEnumerable<Appointment> FilterAppointmentsAsync(string? classification)
        {
           var results =  _context.Appointments.Include(c => c.Classification)
                                               .Where(c => c.Classification == null || c.Classification.Name == classification)
                                               .OrderBy(c => c.Id)
                                               .AsAsyncEnumerable();

            await foreach(var result in results)
            {
                yield return result;
            }
        }

        public async IAsyncEnumerable<Appointment> SearchAppointmentsAsync(AppointmentsSearchCriteria searchCriteria, string classification)
        {
            var results = _context.Appointments.Include(c => c.Classification)
                                                 .Where(x => x.Classification!.Name == classification)
                                                 .Where(x => x.Objective.Contains(searchCriteria.Objective) ||
                                                              x.Reason!.Contains(searchCriteria.Reason) ||
                                                              x.AdditionalInfo!.Contains(searchCriteria.AdditionalInfo))
                                                 .OrderBy(x => x.Id)
                                                 .AsAsyncEnumerable();
            await foreach(var result in results)
            {
                yield return result;
            }
        }




    }
}
