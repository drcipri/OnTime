using OnTime.Models;

namespace OnTime.ViewModels
{
    public class AppointmentsListViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();
        public PaginationInfo PaginationInfo { get; set; } = new();
        public string Classification { get; set; } = string.Empty;
    }
}
