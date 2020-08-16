using NUnit.Framework;

namespace DataProcessor.Library.Tests
{
    public class DataParserTests
    {
        [Test]
        public void ParseData_WithMixedData_ReturnsGoodRecords()
        {
            // Arrange
            var logger = new FakeLogger();
            var parser = new DataParser(logger);

            // Act
            int processedRecords = parser.ParseData(TestData.Data);

            // Assert
            Assert.AreEqual(7, processedRecords);
        }

        [Test]
        public void ParseData_GoodRecord_ReturnsOne()
        {
            // Arrange
            var logger = new FakeLogger();
            var parser = new DataParser(logger);

            // Act
            int processedRecords = parser.ParseData(TestData.GoodRecord);

            // Assert
            Assert.AreEqual(1, processedRecords);
        }

        [Test]
        public void ParseData_BadRecord_ReturnsZero()
        {
            // Arrange
            var logger = new FakeLogger();
            var parser = new DataParser(logger);

            // Act
            int processedRecords = parser.ParseData(TestData.BadRecord);

            // Assert
            Assert.AreEqual(0, processedRecords);
        }

        [Test]
        public void ParseData_BadStartDate_ReturnsZero()
        {
            // Arrange
            var logger = new FakeLogger();
            var parser = new DataParser(logger);

            // Act
            int processedRecords = parser.ParseData(TestData.BadStartDate);

            // Assert
            Assert.AreEqual(0, processedRecords);
        }

        [Test]
        public void ParseData_BadRating_ReturnsZero()
        {
            // Arrange
            var logger = new FakeLogger();
            var parser = new DataParser(logger);

            // Act
            int processedRecords = parser.ParseData(TestData.BadRating);

            // Assert
            Assert.AreEqual(0, processedRecords);
        }
    }
}