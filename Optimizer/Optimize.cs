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
}