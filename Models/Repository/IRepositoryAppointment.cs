namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointment
    {
        IQueryable<Appointment> Appointments { get; }
        IEnumerable<Appointment> FilterAppointments(string? classification);
        void Add(Appointment appointment);
        void RemoveById(int id);
    }
}
