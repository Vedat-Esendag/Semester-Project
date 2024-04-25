using System;
namespace Optimizer
{
    class Program
    {
        public static void Main()
        {
            Analyze analyze = new();
        }
    }

    public class ResultData
    {
        public DateTime TimeFrom;
        public DateTime TimeTo;
        public double HeatDemand;
        public double ElectricityPrice;
        public double HeatProduced;
        public double GasConsumed;
        public double CO2;
    }
}