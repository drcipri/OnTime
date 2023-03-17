using OnTime.Models;

namespace OnTime.Component
{
    public class AppointmentsNavigationViewComponent: ViewComponent
    {
        private readonly IRepositoryClassification _repository;
        public AppointmentsNavigationViewComponent(IRepositoryClassification repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repository.GetAll());
        }
    }
}
