using System;
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
        public void CalculateProductionPrices()
        {
            throw new NotImplementedException();
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