using OnTime.Models.Repository;

namespace OnTime.Controllers
{
    public class HistoryController: Controller
    {
        private readonly IRepositoryAppointmentsAudit _repository;
        public HistoryController(IRepositoryAppointmentsAudit repository)
        {
            _repository = repository;
        }

        public IActionResult AppointmentsHistory()
        {
            return View(_repository.GetAll().OrderByDescending(x => x.Id).AsEnumerable());
        }
    }
}
