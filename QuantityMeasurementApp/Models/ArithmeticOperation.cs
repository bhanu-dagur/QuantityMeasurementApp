using System;

namespace QuantityMeasurementApp.Models
{
    public enum ArithmeticOperation
    {
        ADD,
        SUBTRACT,
        DIVIDE
    }

    public static class ArithmeticOperationExtension
    {
        public static double Compute(this ArithmeticOperation operation, double a, double b)
        {
            return operation switch
            {
                ArithmeticOperation.ADD => a + b,
                ArithmeticOperation.SUBTRACT => a - b,
                ArithmeticOperation.DIVIDE => b == 0
                    ? throw new ArithmeticException("Division by zero")
                    : a / b,
                _ => throw new InvalidOperationException("Unknown arithmetic operation")
            };
        }
    }
}