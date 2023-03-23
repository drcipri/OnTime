namespace OnTime.Models.Repository
{
    public class RepositoryAppointmentsAudit: IRepositoryAppointmentsAudit
    {

        private readonly OnTimeAppointmentsDbContext _context;

        public RepositoryAppointmentsAudit(OnTimeAppointmentsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AppointmentAudit> GetAll()
        {
            return _context.AppointmentsAudit.OrderBy(x => x.Id).AsEnumerable();
        }
    }
}
