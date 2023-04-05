using OnTime.Models;

namespace OnTime.ViewModels
{
    public class AppointmentsListViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();
        public PaginationInfo PaginationInfo { get; set; } = new();
        public string Classification { get; set; } = string.Empty;
        public bool SearchRequest { get; set; } =  false;
        public string SearchCriteria = string.Empty;
    }
}
