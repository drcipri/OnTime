using OnTime.Models;
using OnTime.Models.Repository;
using OnTime.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> AppointmentsHistory()
        {
            List<AppointmentAudit> records = new List<AppointmentAudit>();
            //return results in sequence
            await foreach(var r in _repository.GetAllAsync())
            {
                records.Add(r);
            }
            return View(records.OrderByDescending(x => x.ActionDate));
        }

        [HttpGet]
        public async Task<IActionResult> SearchHistory(string? searchCriteria = null)
        {
            if (!string.IsNullOrEmpty(searchCriteria))
            {
                int appointmentId = default(int);
                Int32.TryParse(searchCriteria, out appointmentId);

                AppointmentsAuditSearchCriteria criteria = new AppointmentsAuditSearchCriteria
                {
                    AppointmentId = appointmentId,
                    ActionType = searchCriteria,
                    Objective = searchCriteria,
                    Reason = searchCriteria,
                    AdditionalInfo = searchCriteria,
                    Classification = searchCriteria
                };
           
                List<AppointmentAudit> recordsFound = new List<AppointmentAudit>();

                await foreach (var r in _repository.SearchAsync(criteria))
                {
                    recordsFound.Add(r);
                }
                return View("AppointmentsHistory", recordsFound.OrderByDescending(x => x.ActionDate));
            }
            return RedirectToRoute("History");

        }

    }
}
