using SourceDataManager;
using AM;

namespace Optimizer
{
    public interface IOptimize
    {
        void CalculateNetProductionWinter(); //passing in arguments lists 
        void CalculateNetProductionSummer(); //List optimize data class, nested for loop

        void ChooseCheapestWinter(); //foreach loop
        void ChooseCheapestSummer(); //argument pricelists
        void OptimizeWinter(); //while loop heatdemand, cheapest gets removed, efficieny rate, ResultData class
        void OptimizeSummer();
    }

    public class Optimize : IOptimize 
    {
        AssetManager assetManager = new AssetManager();
        CsvRead csvRead= new CsvRead();

        public PeriodData GiveData();
        public ProductionUnit GetLowestCostUnit(PeriodData dataPoint, List)

        public void CalculateNetProductionWinter(List<PeriodData> winterData, List<ProductionUnit> productionUnits)
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
        }

    }
}