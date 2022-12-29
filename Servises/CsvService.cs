using CsvHelper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CsvService:ICsvService
    {
        public List<PopulationModel> ReadTradesFromFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("String path is empty. Enter a valid path");
            }
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PopulationModel>().ToList();
                return records;
            }

        }
        public void CsvDataFilling(List<PopulationModel> record)
        {
            Dictionary<string, List<object>> artists = new Dictionary<string, List<object>>();
        }
    }
}
