using System;
using OxyPlot.Series;
using SourceDataManager;
namespace Optimizer
{
    interface IAnalyze
    {
        void CalculateProductionPrices();
        void CreateOrder();
        void CheckMaxHeat();
    }

    public class Analyze : IAnalyze
    {
        CsvRead csvRead = new CsvRead();
        public void CalculateProductionPrices()
        {
            csvRead.ReadCSV();
            double heat = csvRead.winterPeriods[0].HeatDemand;
            Console.WriteLine(heat);
        }

        public void CheckMaxHeat()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}