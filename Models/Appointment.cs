﻿namespace OnTime.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Objective { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string? Reason { get; set; }
        public string? AdditionalInfo { get; set; }
        public Classification Classification { get; set; } = new();
        public int ClassificationId { get; set; }
    }
}