using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace SourceDataManager.Tests
{
    [TestFixture]
    public class GetDataTests
    {
        private readonly string filePath = @"C:\Users\admin\Desktop\SDU\S2\Semester Project 2\Semester Project Code\Semester-Project\Source_Data_Manager\data.csv";

        [Test]
        public void WinterHeatDemand_ReturnsCorrectValues()
        {
            // Arrange

            // Act
            var result = GetData.WinterHeatDemand();

            // Assert
            // Add your assertions here
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<double>>(result);
            // Add more assertions as needed
        }

        [Test]
        public void SummerHeatDemand_ReturnsCorrectString()
        {
            // Arrange

            // Act
            var result = GetData.SummerHeatDemand();

            // Assert
            // Add your assertions here
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<string>(result);
            // Add more assertions as needed
        }

        [Test]
        public void WinterElectricityPrice_ReturnsCorrectString()
        {
            // Arrange

            // Act
            var result = GetData.WinterElectricityPrice();

            // Assert
            // Add your assertions here
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<string>(result);
            // Add more assertions as needed
        }

        [Test]
        public void SummerElectricityPrice_ReturnsCorrectString()
        {
            // Arrange

            // Act
            var result = GetData.SummerElectricityPrice();

            // Assert
            // Add your assertions here
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<string>(result);
            // Add more assertions as needed
        }

        [Test]
        public void WinterHeatDemandTime_ReturnsCorrectValues()
        {
            // Arrange

            // Act
            var result = GetData.WinterHeatDemandTime();

            // Assert
            // Add your assertions here
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<DateTime>>(result);
            // Add more assertions as needed
        }

        [Test]
        public void SummerHeatDemandTime_PrintsCorrectOutput()
        {
            // Arrange
            var expectedOutput = "Summer Heat Demand Time: From {values[6]} To {values[7]}";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                GetData.SummerHeatDemandTime();
                var result = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, result);
            }
        }
    }
}
