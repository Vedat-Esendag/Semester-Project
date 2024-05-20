using NUnit.Framework;
using Optimizer;
using System;
using System.Collections.Generic;
using AM;
using SourceDataManager;

namespace OptimizerTests
{
    [TestFixture]
    public class OptimizeTests
    {
        [Test]
        public void CalculateAndFindCheapest_Test()
        {
            // Arrange
            var optimize = new Optimize();
            var dataPoint = new PeriodData
            {
                HeatDemand = 100,
                ElectricityPrice = 0.12,
                TimeFrom = DateTime.Now,
                TimeTo = DateTime.Now
            };
            var units = new List<ProductionUnit>
            {
                new ProductionUnit
                {
                    Name = "Unit 1",
                    MaxHeat = 50,
                    ProductionCost = 0.5,
                    MaxElectricity = 10,
                    GasConsumption = 5,
                    CO2Emissions = 2
                },
                new ProductionUnit
                {
                    Name = "Unit 2",
                    MaxHeat = 70,
                    ProductionCost = 0.6,
                    MaxElectricity = 15,
                    GasConsumption = 7,
                    CO2Emissions = 3
                }
            };
            var turn = 0;

            // Act
            optimize.CalculateAndFindCheapest(dataPoint, units, turn);

            // Assert
            Assert.AreEqual(1, optimize.resultDatas.Count);
            Assert.AreEqual(1, optimize.producedHeats.Count);
            Assert.AreEqual("Unit 1", optimize.resultDatas[0].UnitName);
        }

        [Test]
        public void OptimizeData_Test()
        {
            // Arrange
            var optimize = new Optimize();
            var winterData = new List<PeriodData>
            {
                new PeriodData { HeatDemand = 100, ElectricityPrice = 0.12 },
                new PeriodData { HeatDemand = 150, ElectricityPrice = 0.15 }
            };

            // Act
            optimize.OptimizeData(winterData);

            // Assert
            Assert.AreEqual(2, optimize.resultDatas.Count);
        }
    }
}
