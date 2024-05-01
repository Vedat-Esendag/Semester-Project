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
        void OptimizeWinter(); //while loop heatdemandel, cheapest gets removed, efficieny rate, ResultData class
        void OptimizeSummer();
    }

    public class Optimize : IOptimize 
    {
        AssetManager assetManager = new AssetManager();
        CsvRead csvRead= new CsvRead();

        public void CalculateNetProductionWinter(List<PeriodData> winterData, List<ProductionUnit> productionUnits)
        {
            for (int i = 0; i<csvRead.winterPeriods.Count(); i++)
            {
                foreach (var unit in assetManager.productionUnits2)
                {
                    
                }
            }
        }

    }
}