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
        public IActionResult Index(int appointmentsPage = 1)
        {
            return View(new AppointmetnsListViewModel
            {
                Appointments = _repository.Appointments.Where(c => c.Classification.Name == ClassificationTypes.Awaiting)
                                                .Include(c => c.Classification)
                                                .OrderBy(c => c.Id)
                                                .Skip((appointmentsPage - 1) * PageSize)
                                                .Take(PageSize)
                                                .ToList(),
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = appointmentsPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Appointments.Where(c => c.Classification.Name == ClassificationTypes.Awaiting).Count()
                }
            });
        }
    }
}
