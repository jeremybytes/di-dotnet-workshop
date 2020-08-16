using PersonReader.CSV;
using System.Threading.Tasks;

namespace PersonReader.CSV.Tests
{
    public class FakeFileLoader : ICSVFileLoader
    {
        private string dataType;

        public FakeFileLoader(string dataType)
        {
            this.dataType = dataType;
        }

        public Task<string> LoadFile()
        {
            switch (dataType)
            {
                case "Good": return Task.FromResult<string>(TestData.WithGoodRecords);
                case "Mixed": return Task.FromResult<string>(TestData.WithGoodAndBadRecords);
                case "Bad": return Task.FromResult<string>(TestData.WithOnlyBadRecords);
                case "Empty": return Task.FromResult<string>(string.Empty);
                default: return Task.FromResult<string>(TestData.WithGoodRecords);
            }
        }
    }
}
