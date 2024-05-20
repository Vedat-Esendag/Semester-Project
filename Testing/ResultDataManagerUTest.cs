using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Moq;
using NUnit.Framework;

namespace Result_Data_Manager.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void CsvWriterCreator_ShouldWriteRecordsToFile()
        {
            // Arrange
            var people = new List<Person>
            {
                new Person { Name = "John", Age = 25, City = "London" },
                new Person { Name = "George", Age = 18, City = "Los angeles" },
                new Person { Name = "Ödön", Age = 45, City = "Patapoklosi" }
            };

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            var filePath = "test_data.csv";
            var fileMock = new Mock<FileWrapper>();

            fileMock.Setup(f => f.Exists(filePath)).Returns(false);
            fileMock.Setup(f => f.Create(filePath)).Verifiable();
            fileMock.Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            // Act
            Program.CsvWriterCreator(filePath);

            // Assert
            fileMock.Verify(f => f.Create(filePath), Times.Once);

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Person>();
                CollectionAssert.AreEqual(people, records);
            }

            // Clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }

    public class FileWrapper
    {
        public virtual bool Exists(string path) => File.Exists(path);
        public virtual FileStream Create(string path) => File.Create(path);
        public virtual void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
    }
}
