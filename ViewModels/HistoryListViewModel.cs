using OnTime.Models;

namespace OnTime.ViewModels
{
    public class HistoryListViewModel
    {
        public IEnumerable<AppointmentAudit> AppointmentAudits { get; set; } = Enumerable.Empty<AppointmentAudit>(); 
        public bool SearchRequest = false;
        public string SearchCriteria { get; set; } = string.Empty;
    }
}
