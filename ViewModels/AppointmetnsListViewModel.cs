using OnTime.Models;

namespace OnTime.ViewModels
{
    public class AppointmetnsListViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();
        public PaginationInfo PaginationInfo { get; set; } = new();
    }
}
