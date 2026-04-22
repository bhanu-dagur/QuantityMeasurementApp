using System.ComponentModel.DataAnnotations;

namespace HistoryService.Models
{
    // Database Table - MeasurementHistory
    public class MeasurementHistory
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public double InputValue1 { get; set; }
        public string InputUnit1 { get; set; } = string.Empty;

        public double? InputValue2 { get; set; }
        public string? InputUnit2 { get; set; }

        public string TargetUnit { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;  // "Conversion", "Addition", etc.
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public class SaveHistoryDTO
    {
        public string UserId { get; set; } = string.Empty;
        public double InputValue1 { get; set; }
        public string InputUnit1 { get; set; } = string.Empty;
        public double? InputValue2 { get; set; }
        public string? InputUnit2 { get; set; }
        public string TargetUnit { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
    }
}
