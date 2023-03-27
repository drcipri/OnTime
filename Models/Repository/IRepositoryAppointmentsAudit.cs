using OnTime.ViewModels;

namespace OnTime.Models.Repository
{
    public interface IRepositoryAppointmentsAudit
    {
        IQueryable<AppointmentAudit> AppointmentsAudit { get; }
        IEnumerable<AppointmentAudit> GetAll();
        IAsyncEnumerable<AppointmentAudit> GetAllAsync();
        IAsyncEnumerable<AppointmentAudit> SearchAsync(AppointmentsAuditSearchCriteria criteria);
    }
}
