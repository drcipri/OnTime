using Microsoft.EntityFrameworkCore;
using OnTime.Models;
using OnTime.Models.Repository;
using OnTime.ViewModels;

namespace OnTime.Controllers
{
    public class HomeController: Controller
    {
        private readonly IRepositoryAppointment _repository;

        //PageSize-> How many objects will be on a page
        public int PageSize = 4;
        public HomeController(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async  Task<IActionResult> Index(int appointmentsPage = 1, string? classification = null)
        {
            var getAppointments = new List<Appointment>();
            await foreach(var item in _repository.FilterAppointmentsAsync(String.IsNullOrEmpty(classification) ? ClassificationTypes.Awaiting : classification))
            {
                getAppointments.Add(item);
            }
            return View(new AppointmentsListViewModel
            {
                Appointments = getAppointments.OrderByDescending(c => c.PostDateTime) //get data in desceding order by posted date. This way the last one posted will be the first to show
                                               .Skip((appointmentsPage - 1) * PageSize)
                                               .Take(PageSize)
                                               .ToList(),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = appointmentsPage,
                    ItemsPerPage = PageSize,
                    TotalItems = getAppointments.Count()
                },
                Classification = String.IsNullOrEmpty(classification) ? ClassificationTypes.Awaiting : classification
            });
        }
       
        [HttpGet]
        public async Task<IActionResult> SearchIndex(string? classification = null, string? searchCriteria = null, int appointmentsPage = 1) 
        { 
            if(!string.IsNullOrEmpty(searchCriteria) && !string.IsNullOrEmpty(classification))
            {
                var criteria = new AppointmentsSearchCriteria
                {
                    Objective = searchCriteria,
                    Reason = searchCriteria,
                    AdditionalInfo = searchCriteria,
                    Classification = searchCriteria
                };

                List<Appointment> appointments = new List<Appointment>();

                await foreach(var r in _repository.SearchAppointmentsAsync(criteria,classification))
                {
                    appointments.Add(r);    
                }

                return View("Index", new AppointmentsListViewModel
                {
                    Appointments = appointments.OrderByDescending(c => c.PostDateTime)
                                               .Skip((appointmentsPage - 1) * PageSize)
                                               .Take(PageSize)
                                               .ToList(),
                    PaginationInfo = new PaginationInfo
                    {
                        CurrentPage = appointmentsPage,
                        ItemsPerPage = PageSize,
                        TotalItems = appointments.Count()
                    },
                    Classification = classification,
                    SearchRequest = true,
                    SearchCriteria = searchCriteria
                });
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
