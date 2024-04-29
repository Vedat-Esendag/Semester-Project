using System;
using OxyPlot.Series;
using SourceDataManager;
using AM;

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
        List<double> productionPrices = new List<double>();
        CsvRead csvRead = new CsvRead();
        AssetManager assetManager = new AssetManager();

        OilBoiler oilBoiler = new OilBoiler();
        GasBoiler gasBoiler = new GasBoiler();

        GasMotor gasMotor = new GasMotor();
        ElectricBoiler electricBoiler= new ElectricBoiler();

        public void CalculateProductionPricesWinter()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double price = (csvRead.winterPeriods[0].HeatDemand*assetManager.OilBoiler.ProductionCost)+(csvRead.winterPeriods[0].ElectricityPrice);
            }
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