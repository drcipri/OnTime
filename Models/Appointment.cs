using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace OnTime.Models
{
    public class Appointment
    {
        //Bind never because the ID will be set by the Database.
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter appointment/task objective")]
        public string Objective { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter Appointment/task Date and Time")]
        public DateTime AppointmentDateTime { get; set; }
        public DateTime PostDateTime { get; set; }
        public string? Reason { get; set; }
        public string? AdditionalInfo { get; set; }
        public Classification? Classification { get; set; }
        public int ClassificationId { get; set; }
    }
}
