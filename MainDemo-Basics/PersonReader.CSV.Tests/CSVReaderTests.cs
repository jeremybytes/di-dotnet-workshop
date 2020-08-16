using NUnit.Framework;
using System.IO;
using System.Linq;

namespace PersonReader.CSV.Tests
{
    public class CSVReaderTests
    {
        [Test]
        public void GetPeople_WithEmptyFile_ReturnsEmptyList()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Empty");

            var result = repository.GetPeople();

            Assert.IsEmpty(result);
        }

        [Test]
        public void GetTask_WithBadFileName_ThrowsFileNotFoundException()
        {
            // Note: "People.txt" file does not exist
            //       in the test context
            var repository = new CSVReader();

            try
            {
                var result = repository.GetPeople();
                Assert.Fail();
            }
            catch (FileNotFoundException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void GetPeople_WithGoodRecords_ReturnsGoodRecords()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Good");

            var result = repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetPeople_WithBadRecords_ReturnsGoodRecords()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Mixed");

            var result = repository.GetPeople();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void GetPeople_WithOnlyBadRecord_ReturnsEmptyList()
        {
            var repository = new CSVReader();
            repository.FileLoader = new FakeFileLoader("Bad");

            var result = repository.GetPeople();

            Assert.IsEmpty(result);
        }
    }
}
