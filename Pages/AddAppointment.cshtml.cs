using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnTime.Models;

namespace OnTime.Pages
{
    public class AddAppointmentModel : PageModel
    {
        private readonly IRepositoryAppointment _repository;
        [BindProperty]
        public Appointment AddAppointment { get; set; } = new();
        [BindProperty]
        public Appointment? RemoveAppointment { get; set; }
        public AddAppointmentModel(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            AddAppointment.PostDateTime = DateTime.Now;
            AddAppointment.ClassificationId = 1;
            
            if(ModelState.IsValid)
            {
                _repository.Add(AddAppointment);
                return RedirectToRoute(new { Controller = "Home", action = "Index", classification = ClassificationTypes.Awaiting });
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPostRemove(int appointmentId, string urlClassification)
        {
            _repository.RemoveById(appointmentId);
            return RedirectToRoute(new  { Controller = "Home", action = "Index", classification = urlClassification });

        }
    }
}
