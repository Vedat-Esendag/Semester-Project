using System;
using SourceDataManager;
namespace Optimizer
{
    class Program
    {
        public static void Main()
        {
            GetData getData = new();
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