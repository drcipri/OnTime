namespace OnTime.ViewModels
{
    public class AppointmentsAuditSearchCriteria
    {
        public string ActionType { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string AdditionalInfo { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public int AppointmentId { get; set; }
    }
}
