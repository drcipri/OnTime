using Microsoft.EntityFrameworkCore;

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
    }
}
