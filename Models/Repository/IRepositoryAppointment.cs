using OnTime.ViewModels;

namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointment
    {
        IQueryable<Appointment> Appointments { get; }
        IAsyncEnumerable<Appointment> FilterAppointmentsAsync(string? classification);
        void AddAppointment(Appointment appointment);
        bool RemoveById(int id);
        bool MarkAppointment(int id, string classificationName);
        Appointment? GetAppointment(int id);
        void UpdateAppointment(Appointment appointment);
        IAsyncEnumerable<Appointment> SearchAppointmentsAsync(AppointmentsSearchCriteria searchCriteria, string classification);
    }
}
