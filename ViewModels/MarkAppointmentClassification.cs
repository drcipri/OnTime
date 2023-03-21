namespace OnTime.ViewModels
{
    public class MarkAppointmentClassification
    {
        public IEnumerable<string> Classifications { get; set; } = Enumerable.Empty<string>();
        public int AppointmentId { get; set; }
        public string? CurrentClassification { get; set; }

    }
}
