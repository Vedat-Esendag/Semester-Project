using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq; // Ensure this is included
using Result_Data_Manager;
using Optimizer;
using SourceDataManager;

namespace Result_Data_Manager_Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CsvWriterCreator_WritesRecordsSuccessfully()
        {
            // Arrange
            var mockStreamWriter = new Mock<StreamWriter>("dummyFilePath", true);
            var mockCsvWriter = new Mock<CsvWriter>(mockStreamWriter.Object, new CsvConfiguration(CultureInfo.InvariantCulture));
            var optimizerMock = new Mock<Optimize>();
            optimizerMock.Setup(o => o.resultDatas).Returns(GetDummyResultData().ToList());

            // Act
            Program.CsvWriterCreator("dummyFilePath");

            // Assert
            mockCsvWriter.Verify(w => w.WriteRecords(It.IsAny<IEnumerable<ResultData>>()), Times.Once);
        }

        [TestMethod]
        public void Main_CreatesFileAndWritesCsvWhenFileIsEmpty()
        {
            // Arrange
            var path = "./";
            var fileName = "result.csv";
            var filePath = Path.Combine(path, fileName);

            var csvReadMock = new Mock<CsvRead>();
            var optimizerMock = new Mock<Optimize>();

            csvReadMock.Setup(cr => cr.ReadCSV());
            optimizerMock.Setup(o => o.OptimizeData(It.IsAny<List<PeriodData>>())); // Ensure the correct type here

            var fileMock = new Mock<FileInfo>(filePath);
            fileMock.Setup(f => f.Exists).Returns(false);
            fileMock.Setup(f => f.Length).Returns(0);

            // Act
            Program.Main(new string[] { });

            // Assert
            csvReadMock.Verify(cr => cr.ReadCSV(), Times.Once);
            optimizerMock.Verify(o => o.OptimizeData(It.IsAny<List<PeriodData>>()), Times.Once); // Ensure the correct type here
            optimizerMock.Verify(o => o.OptimizeData(It.IsAny<List<PeriodData>>()), Times.Once); // Ensure the correct type here
            Assert.IsTrue(File.Exists(filePath));
            Assert.IsTrue(new FileInfo(filePath).Length > 0);
        }

        private List<ResultData> GetDummyResultData()
        {
            return new List<ResultData>
            {
                new ResultData(
                    "Unit1", // string name
                    DateTime.Now, // DateTime timeFrom
                    DateTime.Now.AddHours(1), // DateTime timeTo
                    100, // double heatDemand
                    80, // double heatProduced
                    50, // double electricityPrice
                    30, // double electricity
                    20, // double expenses
                    10, // double primaryEnergyConsumed
                    5 // double co2
                )
            };
        }
    }
}
