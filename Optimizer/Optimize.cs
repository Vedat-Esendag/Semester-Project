using SourceDataManager;
using AM;

namespace Optimizer
{
    public interface IOptimize
    {
        void CalculateAndFindCheapest(PeriodData dataPoint, List<ProductionUnit> units, int turn);
        void OptimizeData(List<PeriodData> winterData);
    }

    public class Optimize : IOptimize
    {
        AssetManager assetManager = new AssetManager();
        CsvRead csvRead = new CsvRead(); 
        public List<double> producedHeats = new List<double>();

        public List<ResultData> resultDatas= new List<ResultData>();

        public void CalculateAndFindCheapest(PeriodData dataPoint, List<ProductionUnit> units, int turn) 
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
            foreach (ProductionUnit unit1 in units)
            {
                double efficiencyRate =  dataPoint.HeatDemand / unit1.MaxHeat;
                if (efficiencyRate > 1)
                    efficiencyRate = 1;
                
                if(unit1.netCosts == costs[turn])
                {
                    producedHeats.Add(unit1.MaxHeat*efficiencyRate);
                    ResultData resultData = new ResultData
                    (
                        unit1.Name, 
                        dataPoint.TimeFrom, 
                        dataPoint.TimeTo, 
                        dataPoint.HeatDemand, 
                        unit1.MaxElectricity*efficiencyRate, 
                        unit1.netCosts, 
                        dataPoint.ElectricityPrice, 
                        unit1.MaxHeat*efficiencyRate, 
                        unit1.GasConsumption*efficiencyRate,
                        unit1.CO2Emissions*efficiencyRate
                    );

                    resultDatas.Add(resultData);
                }
            }
        }
        public void OptimizeData(List<PeriodData> winterData)
        {
            for (int i = 0; i < winterData.Count(); i++)
            {
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
                    CalculateAndFindCheapest(winterData[i], currentUnits, count);
                    winterData[i].HeatDemand -= producedHeats[count];
                    count++;
                }
            }
        }
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
}