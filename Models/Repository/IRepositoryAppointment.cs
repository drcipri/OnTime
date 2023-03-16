namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointment
    {
        IQueryable<Appointment> Appointments { get; }
    }
}
