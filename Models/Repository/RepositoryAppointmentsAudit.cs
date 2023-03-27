using Microsoft.EntityFrameworkCore;
using OnTime.ViewModels;

namespace OnTime.Models.Repository
{
    public class RepositoryAppointmentsAudit: IRepositoryAppointmentsAudit
    {

        private readonly OnTimeAppointmentsDbContext _context;

        public RepositoryAppointmentsAudit(OnTimeAppointmentsDbContext context)
        {
            _context = context;
        }

        public IQueryable<AppointmentAudit> AppointmentsAudit => _context.AppointmentsAudit; 

        public IEnumerable<AppointmentAudit> GetAll()
        {
            return _context.AppointmentsAudit.OrderBy(x => x.Id).AsEnumerable();
        }
      
        public async IAsyncEnumerable<AppointmentAudit> GetAllAsync()
        {
            var result =  _context.AppointmentsAudit.OrderBy(x => x.Id).AsAsyncEnumerable();
            await foreach(var r in result)
            {
                yield return r;
            }
        }
       
        public async IAsyncEnumerable<AppointmentAudit> SearchAsync(AppointmentsAuditSearchCriteria criteria)
        {
            var queryResult = _context.AppointmentsAudit.Where(c => c.AppointmentId == criteria.AppointmentId ||
                                                              c.Classification.Contains(criteria.Classification) ||
                                                              c.ActionType.Contains(criteria.ActionType) ||
                                                              c.Objective.Contains(criteria.Objective) ||
                                                              c.Reason.Contains(criteria.Reason) ||
                                                              c.AdditionalInfo.Contains(criteria.AdditionalInfo)).OrderBy(x => x.ActionDate).AsAsyncEnumerable();
            await foreach(var r in queryResult)
            {
                yield return r;
            }
        }
    }
}
