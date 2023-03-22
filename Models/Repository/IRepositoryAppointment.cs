namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointment
    {
        IQueryable<Appointment> Appointments { get; }
        IEnumerable<Appointment> FilterAppointments(string? classification);
        void AddAppointment(Appointment appointment);
        void RemoveById(int id);
        void MarkAppointment(int id, string classificationName);
        Appointment? GetAppointment(int id);
        void UpdateAppointment(Appointment appointment);
    }
}
