using SourceDataManager;
using AM;

namespace Optimizer
{
    public interface IOptimize
    {
        void CalculateNetProductionWinter();
        void CalculateNetProductionSummer();

        void ChooseCheapestWinter();
        void ChooseCheapestSUmmer(); 
        void OptimizeWinter(); //while loop, cheapest gets removed, efficieny rate, ResultData class
        void OptimizeSummer();
    }
}