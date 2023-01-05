using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICsvService
    {
        public List<PopulationModel> ReadTradesFromFile(string filename);
        public Task CsvDataFilling(List<PopulationModel> countries);
    }
}
