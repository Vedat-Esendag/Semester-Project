using SourceDataManager;
using AM;
using OxyPlot;
using System.Security.Cryptography.X509Certificates;

namespace Optimizer
{
    public interface IOptimize
    {
        // double list for winter summer
        void CalculateNetProductionWinter(); //passing in arguments lists 
        void CalculateNetProductionSummer(); //List optimize data class, nested for loop

        void ChooseCheapestWinter(); //foreach loop
        void ChooseCheapestSummer(); //argument pricelists
        void OptimizeWinter(); //while loop heatdemand, cheapest gets removed, efficieny rate, ResultData class
        void OptimizeSummer();
    }

    public class Optimize //  : IOptimize 
    {
        AssetManager assetManager = new AssetManager();
        CsvRead csvRead= new CsvRead();
        //List<ProductionUnit> cheapestUnits = new List<ProductionUnit>();  
        List<double> producedHeats = new List<double>();
        public List<ResultData> resultDatas= new List<ResultData>();

        public void CalculateAndFindCheapestWinter(PeriodData dataPoint, List<ProductionUnit> units, int turn) //null checking the datapoint required //return production unit?
        // Asset manager price variable and set it here 
        {
            List<double> costs = new List<double>();
            foreach(ProductionUnit unit in units)
            {
                double efficiencyRate = dataPoint.HeatDemand / unit.MaxHeat;
                double cost = (dataPoint.HeatDemand * unit.ProductionCost) + (dataPoint.ElectricityPrice * unit.MaxElectricity * efficiencyRate);
                unit.netCosts = cost;
                costs.Add(cost);
            }
            costs.Sort();
            double cheapestPrice = costs[0]; // Lista sort kell e?
            double secondCheapestPrice = costs[1];
            double thirdCheapestPrice = costs[2];
            costs.Clear();
            //ProductionUnit cheapestUnit;
            //ProductionUnit secondCheapestUnit;
            //ProductionUnit thirdCheapestUnit;
            foreach (ProductionUnit unit1 in units)
            {
                double efficiencyRate =  dataPoint.HeatDemand / unit1.MaxHeat;
                if (turn == 0)
                {
                    if(unit1.netCosts == cheapestPrice)
                    {
                        //cheapestUnit = unit1;
                        //cheapestUnits.Add(cheapestUnit);
                        if(efficiencyRate <= 1)
                        {
                            producedHeats.Add(unit1.MaxHeat*efficiencyRate);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity*efficiencyRate, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat*efficiencyRate, unit1.GasConsumption*efficiencyRate,
                            unit1.CO2Emissions*efficiencyRate);
                            resultDatas.Add(resultData);
                        }
                        else 
                        {
                            producedHeats.Add(unit1.MaxHeat);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat, unit1.GasConsumption,
                            unit1.CO2Emissions);
                            resultDatas.Add(resultData);
                        }
                    }
                }
                else if (turn == 1)
                {
                    // units.Remove(cheapestUnit);
                    if(unit1.netCosts == secondCheapestPrice)
                    {
                        //secondCheapestUnit = unit1;
                        //cheapestUnits.Add(secondCheapestUnit);
                        // units.Remove(cheapestUnit); ??
                        if(efficiencyRate <= 1)
                        {
                            producedHeats.Add(unit1.MaxHeat*efficiencyRate);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity*efficiencyRate, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat*efficiencyRate, unit1.GasConsumption*efficiencyRate,
                            unit1.CO2Emissions*efficiencyRate);
                            resultDatas.Add(resultData);
                        }
                        else 
                        {
                            producedHeats.Add(unit1.MaxHeat);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat, unit1.GasConsumption,
                            unit1.CO2Emissions);
                            resultDatas.Add(resultData);
                        }
                    }
                }
                else
                {
                    // units.Remove(secondCheapestUnit); ??
                    if(unit1.netCosts == thirdCheapestPrice)
                    {
                        //thirdCheapestUnit = unit1;
                        //cheapestUnits.Add(thirdCheapestUnit);
                        if(efficiencyRate <= 1)
                        {
                            producedHeats.Add(unit1.MaxHeat*efficiencyRate);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity*efficiencyRate, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat*efficiencyRate, unit1.GasConsumption*efficiencyRate,
                            unit1.CO2Emissions*efficiencyRate);
                            resultDatas.Add(resultData);
                        }
                        else 
                        {
                            producedHeats.Add(unit1.MaxHeat);
                            ResultData resultData = new ResultData(unit1.Name, dataPoint.TimeFrom, dataPoint.TimeTo, dataPoint.HeatDemand, 
                            unit1.MaxElectricity, unit1.netCosts, dataPoint.ElectricityPrice, unit1.MaxHeat, unit1.GasConsumption,
                            unit1.CO2Emissions);
                            resultDatas.Add(resultData);
                        }
                    }
                }
            }
        }

         // other method with for loop to have min of unit netcost

         //Call this method in the program?
        public void ChooseCheapestWinter(List<PeriodData> winterData)  //Choose the one unit with the lowest netCost
        {
            for (int i = 0; i < winterData.Count(); i++) // for i lista jobb talan
            {
                // while loop here with the heat demand and removal of unit how?
                assetManager.AddBoilers();
                List<ProductionUnit> currentUnits = new List<ProductionUnit>();
                foreach (ProductionUnit unit in assetManager.productionUnits2)
                {
                    currentUnits.Add(unit);
                }
                int count = 0;
                producedHeats.Clear();
                while(winterData[i].HeatDemand > 0)
                {
                    CalculateAndFindCheapestWinter(winterData[i], currentUnits, count);
                    winterData[i].HeatDemand -= producedHeats[count];
                    //currentUnits.Remove(cheapestUnits[i]); ???
                    count++;
                }
            }
        }

        public void AssignResultData()
        {
            //AssignResultData from the cheapest units list???
        }

    public class ResultData
    {
        public string UnitName;
        public DateTime TimeFrom;
        public DateTime TimeTo;
        public double HeatDemand;
        public double Electricity;
        public double Expenses;
        public double ElectricityPrice;
        public double HeatProduced;
        public double PrimaryEnergyConsumed;
        public double CO2;

        public ResultData(string name, DateTime timeFrom, DateTime timeTo, double heatDemand, double electricity, double expenses, double electricityPrice, double heatProduced, double primaryEnergy, double co2) 
        {
            UnitName = name;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            HeatDemand = heatDemand;
            Electricity = electricity;
            Expenses = expenses;
            ElectricityPrice = electricityPrice;
            HeatProduced = heatProduced;
            PrimaryEnergyConsumed = primaryEnergy;
            CO2 = co2;
        }
    }

        /*public void CalculateNetProductionWinter(List<PeriodData> winterData, List<ProductionUnit> productionUnits)
        {
            List<ResultData> resultDatas = new();

            foreach (PeriodData dataPoint in winterData)
            {

            }

            for (int i = 0; i<csvRead.winterPeriods.Count(); i++)
            {
                foreach (var unit in assetManager.productionUnits2)
                {
                    
                }
            }
        }*/

    }
}
