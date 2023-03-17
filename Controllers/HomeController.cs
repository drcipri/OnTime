using Microsoft.EntityFrameworkCore;
using OnTime.Models;
using OnTime.Models.Repository;
using OnTime.ViewModels;

namespace OnTime.Controllers
{
    public class HomeController: Controller
    {
        private readonly IRepositoryAppointment _repository;

        public int PageSize = 4;
        public HomeController(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public IActionResult Index(int appointmentsPage = 1, string? classification = null)
        {
            return View(new AppointmentsListViewModel
            {
                Appointments = _repository.FilterAppointments(String.IsNullOrEmpty(classification) ? ClassificationTypes.Awaiting : classification)
                                                .Skip((appointmentsPage - 1) * PageSize)
                                                .Take(PageSize)
                                                .ToList(),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = appointmentsPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.FilterAppointments(String.IsNullOrEmpty(classification) ? ClassificationTypes.Awaiting : classification).Count()
                },
                Classification = String.IsNullOrEmpty(classification) ? ClassificationTypes.Awaiting : classification 
            });
        }
    }
}
