using Services;
using System.Reflection;

namespace TEstServices
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Reader_SErvice_Contains_Dto()
        {
            var dir = Assembly.GetExecutingAssembly().Location;
            var file = Path.Combine(Path.GetDirectoryName(dir), "drinks.csv");
            CsvService csv = new CsvService();
            var res=csv.ReadTradesFromFile(file);
            Assert.NotEmpty(res);
        }
    }
}