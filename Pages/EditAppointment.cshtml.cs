using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnTime.Models;

namespace OnTime.Pages
{
    public class EditAppointmentModel : PageModel
    {
        private readonly IRepositoryAppointment _repository;
        [BindProperty]
        public Appointment EditAppointment { get; set; } = new();
        public EditAppointmentModel(IRepositoryAppointment repository)
        {
            _repository = repository;
        }
        public void OnGet(int appointmentId)
        {
           var appointment =  _repository.GetAppointment(appointmentId);
            if(appointment != null)
            {
                EditAppointment = appointment;
            }
        }
        public IActionResult OnPost(int appointmentId) 
        {
            if(ModelState.IsValid)
            {
                //Id property cannot be binded because there is an[BindNever] attribute to prevent that 
                //The workaround is to pass the value through a parameter
                EditAppointment.Id = appointmentId;

                _repository.UpdateAppointment(EditAppointment);
            }
            else
            {
                return Page();
            }
            return RedirectToRoute(new { Controller = "Home", action = "Index", classification = EditAppointment?.Classification?.Name });
        }

        public IActionResult OnPostMarkAs(int appointmentId, string classificationName)
        {
            _repository.MarkAppointment(appointmentId, classificationName);
            return RedirectToRoute(new { Controller = "Home", action = "Index", classification = classificationName });
        }
    }
}
