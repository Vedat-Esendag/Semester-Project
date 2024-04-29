using System;
using OxyPlot.Series;
using SourceDataManager;
using AM;

namespace Optimizer
{
    interface IAnalyze
    {
        void CalculatePricesWinterElectric();
        void CalculatePricesWinterOil();
        void CalculatePricesWinterMotor();
        void CalculatePricesWinterGas();
        void CalculatePricesSummerElectric();
        void CalculatePricesSummerOil();
        void CalculatePricesSummerMotor();
        void CalculatePricesSummerGas();
        void CreateOrder();
        void CheckMaxHeat();
    }

    public class Analyze : IAnalyze
    {
        List<double> oilWinterProductionPrices = new List<double>();
        List<double> oilSummerProductionPrices = new List<double>();

        List<double> gasWinterProductionPrices = new List<double>();
        List<double> gasSummerProductionPrices = new List<double>();

        List<double> motorWinterProductionPrices = new List<double>();
        List<double> motorSummerProductionPrices = new List<double>();

        List<double> electricWinterProductionPrices = new List<double>();
        List<double> electricSummerProductionPrices = new List<double>();



        CsvRead csvRead = new CsvRead();
        AssetManager assetManager = new AssetManager();

        OilBoiler oilBoiler = new OilBoiler();
        GasBoiler gasBoiler = new GasBoiler();

        GasMotor gasMotor = new GasMotor();
        ElectricBoiler electricBoiler= new ElectricBoiler();



        double efficiencyRate;
        public void CalculatePricesWinterOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                efficiencyRate = csvRead.winterPeriods[i].HeatDemand / oilBoiler.MaxHeat;
                if(efficiencyRate <= 1)
                {
                    double price = (csvRead.winterPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity*efficiencyRate);
                    oilWinterProductionPrices.Add(price);
                }
            }
        }

        public void CalculatePricesSummerOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double price = (csvRead.summerPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity);
                oilSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double price = (csvRead.winterPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity);
                gasWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double price = (csvRead.summerPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity);
                gasSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double price = (csvRead.winterPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasMotor.MaxElectricity);
                motorWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double price = (csvRead.summerPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasMotor.MaxElectricity);
                motorSummerProductionPrices.Add(price);
            }

            for (int i = 0; i<motorSummerProductionPrices.Count;i++)
            {
                Console.WriteLine("Motor" +motorSummerProductionPrices[i]);
            }
        }

        public void CalculatePricesWinterElectric()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double price = (csvRead.winterPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity);
                electricWinterProductionPrices.Add(price);
            }

            for (int i = 0; i<electricWinterProductionPrices.Count;i++)
            {
                Console.WriteLine("Electric"+electricWinterProductionPrices[i]);
            }
        }

        public void CalculatePricesSummerElectric()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double price = (csvRead.summerPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity);
                electricSummerProductionPrices.Add(price);
            }
        }



        public void CheckMaxHeat()
        {
           
        }

        public void CreateOrder()
        {
            
        }
    }
}