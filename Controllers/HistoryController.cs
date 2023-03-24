using OnTime.Models;
using OnTime.Models.Repository;
using System.Linq;

namespace OnTime.Controllers
{
    public class HistoryController: Controller
    {
        private readonly IRepositoryAppointmentsAudit _repository;
        public HistoryController(IRepositoryAppointmentsAudit repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> AppointmentsHistory()
        {
            List<AppointmentAudit> records = new List<AppointmentAudit>();
            //return results in sequence
            await foreach(var r in _repository.GetAllAsync())
            {
                records.Add(r);
            }
            return View(records.OrderByDescending(x => x.Id));
        }
       
    }
}
