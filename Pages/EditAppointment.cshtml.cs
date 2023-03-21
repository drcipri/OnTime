using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnTime.Models;

namespace OnTime.Pages
{
    public class EditAppointmentModel : PageModel
    {
        private readonly IRepositoryAppointment _repository;
       
        public EditAppointmentModel(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
        }

        public IActionResult OnPostMarkAs(int appointmentId, string classificationName)
        {
            _repository.MarkAppointment(appointmentId, classificationName);
            return RedirectToRoute(new { Controller = "Home", action = "Index", classification = classificationName });
        }
    }
}
