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

        public void CalculatePricesWinterOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / oilBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity*efficiencyRate);
                oilWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerOil()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / oilBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*oilBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*oilBoiler.MaxElectricity*efficiencyRate);
                oilSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / gasBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity*efficiencyRate);
                gasWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerGas()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / gasBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*gasBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasBoiler.MaxElectricity*efficiencyRate);
                gasSummerProductionPrices.Add(price);
            }
        }

        public void CalculatePricesWinterMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.winterPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / gasMotor.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*gasMotor.MaxElectricity*efficiencyRate);
                motorWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerMotor()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / gasMotor.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*gasMotor.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*gasMotor.MaxElectricity*efficiencyRate);
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
                double efficiencyRate = csvRead.winterPeriods[i].HeatDemand / electricBoiler.MaxHeat;
                double price = (csvRead.winterPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.winterPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity*efficiencyRate);
                electricWinterProductionPrices.Add(price);
            }
        }

        public void CalculatePricesSummerElectric()
        {
            csvRead.ReadCSV();
            for (int i = 0; i < csvRead.summerPeriods.Count(); i++)
            {
                double efficiencyRate = csvRead.summerPeriods[i].HeatDemand / electricBoiler.MaxHeat;
                double price = (csvRead.summerPeriods[i].HeatDemand*electricBoiler.ProductionCost)+(csvRead.summerPeriods[i].ElectricityPrice*electricBoiler.MaxElectricity*efficiencyRate);
                electricSummerProductionPrices.Add(price);
            }

            
            for (int i = 0; i<electricSummerProductionPrices.Count;i++)
            {
                Console.WriteLine("Electric"+electricSummerProductionPrices[i]);
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