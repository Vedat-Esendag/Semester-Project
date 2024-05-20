using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace AM.Tests
{
    [TestFixture]
    public class AssetManagerTests
    {
        [Test]
        public void AddBoilersAndSaveState_AddsBoilersAndSavesToFile()
        {
            // Arrange
            var assetManager = new AssetManager();
            var filePath = "testDirectory";

            // Act
            assetManager.AddBoilersAndSaveState(filePath);

            // Assert
            // Verify that AddBoilers method was called
            Assert.AreEqual(2, assetManager.productionUnits1.Count);
            Assert.AreEqual(4, assetManager.productionUnits2.Count);

            // Verify that SaveBoilers method was called with the correct file paths
            Assert.IsTrue(File.Exists(Path.Combine(filePath, "json1.json")));
            Assert.IsTrue(File.Exists(Path.Combine(filePath, "json2.json")));
        }
    }
}
