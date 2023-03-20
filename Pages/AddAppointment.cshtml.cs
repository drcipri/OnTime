using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnTime.Models;

namespace OnTime.Pages
{
    public class AddAppointmentModel : PageModel
    {
        private readonly IRepositoryAppointment _repository;
        [BindProperty]
        public Appointment Appointment { get; set; } = new();
        public AddAppointmentModel(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Appointment.PostDateTime = DateTime.Now;
            Appointment.ClassificationId = 1;
            
            if(ModelState.IsValid)
            {
                _repository.Add(Appointment);
                return RedirectToRoute(new { Controller = "Home", action = "Index", classification = ClassificationTypes.Awaiting });
            }
            else
            {
                return Page();
            }
        }
    }
}
