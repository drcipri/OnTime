namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointmentsAudit
    {
        IEnumerable<AppointmentAudit> GetAll(); 
    }
}
