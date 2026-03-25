using QuantityMeasurementAppModelLayer.Core;
using QuantityMeasurementAppModelLayer.DTO;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IMeasurementService
    {
        QuantityDTO PerformAddition(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        QuantityDTO PerformConversion(QuantityDTO q ,string toUnit);
        QuantityDTO PerformSubtraction(QuantityDTO q1, QuantityDTO q2, string targetUnit);
        bool CheckEquality(QuantityDTO q1, QuantityDTO q2);
    }
}
    