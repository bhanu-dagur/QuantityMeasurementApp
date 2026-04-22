namespace MeasurementService.Models
{
    // ============================
    // EnumIndex Map:
    //   1 = Length
    //   2 = Weight
    //   3 = Volume
    //   4 = Temperature
    // ============================

    // Single quantity (conversion ke liye)
    public class QuantityDTO
    {
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;  // e.g. "FEET", "KILOGRAM"
        public int EnumIndex { get; set; }                 // 1=Length, 2=Weight, 3=Volume, 4=Temp
    }

    // Two quantities (arithmetic ke liye)
    public class ArithmeticDTO
    {
        public QuantityDTO Quantity1 { get; set; } = new();
        public QuantityDTO Quantity2 { get; set; } = new();
    }

    // Response DTO
    public class ResultDTO
    {
        public double ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
    }

    // History save karne ke liye HistoryService ko bheja jata hai
    public class HistoryPayloadDTO
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
