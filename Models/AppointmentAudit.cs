namespace OnTime.Models
{
    public class AppointmentAudit
    {
        public int Id { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Objective { get; set; } = string.Empty;
        public string? Reason { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Classification { get; set; }
        public int AppointmentId { get; set; }


    }
}
