using SourceDataManager;
using AM;

namespace Optimizer
{
    public interface IOptimize
    {
        void CalculateNetProductionWinter(); //passing in arguments lists 
        void CalculateNetProductionSummer(); //List optimize data class, nested for loop

        void ChooseCheapestWinter(); //foreach loop
        void ChooseCheapestSUmmer(); //argument pricelists
        void OptimizeWinter(); //while loop heatdemandel, cheapest gets removed, efficieny rate, ResultData class
        void OptimizeSummer();
    }

    public class Optimize : IOptimize 
    {
        AssetManager assetManager = new AssetManager();
        public void MethodTest()
        {
            assetManager.AddBoilers();
            for (int i = 0; i < assetManager.productionUnits2.Count(); i++)
            {
                Console.WriteLine("Object:" + assetManager.productionUnits2[i]);
                Console.WriteLine("" + assetManager.productionUnits2[i].ProductionCost);
            }
        }
    }
}