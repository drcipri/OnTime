using Microsoft.EntityFrameworkCore;
using OnTime.Models;
using OnTime.Models.Repository;

namespace OnTime.Controllers
{
    public class HomeController: Controller
    {
        private readonly IRepositoryAppointment _repository;
        public HomeController(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            return View(_repository.Appointments.Where(c => c.ClassificationId == 1 && c.Classification.Name == ClassificationTypes.Awaiting)
                                                .Include(c => c.Classification)
                                                .OrderBy(c => c.Id).ToList());
        }
    }
}
