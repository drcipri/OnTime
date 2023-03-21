using OnTime.ViewModels;

namespace OnTime.Component
{
    public class AppointmentClassificationViewComponent: ViewComponent
    {
        private readonly IRepositoryClassification _repository;
        public AppointmentClassificationViewComponent(IRepositoryClassification repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int appointmentId, string currentClassification)
        {
            return View(new MarkAppointmentClassification
            {
                Classifications = _repository.GetAll().Select(c => c.Name),
                AppointmentId = appointmentId,
                CurrentClassification= currentClassification
            });
        }
    }
}
