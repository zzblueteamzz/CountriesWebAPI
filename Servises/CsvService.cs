using CsvHelper;
using Data.Context;
using Data.Models;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CsvService : ICsvService
    {
        public readonly CountriesContext _countriesContext;
        public CsvService(CountriesContext countriesContext)
        {
            _countriesContext = countriesContext;
        }

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
        public async Task CsvDataFilling(List<PopulationModel> countries)
        {
            foreach (PopulationModel country in countries)
            {
                Country newCountry = new Country() { CountryName = country.CountryName };
                await _countriesContext.AddAsync(newCountry);
            }
            await _countriesContext.SaveChangesAsync();
            foreach (PopulationModel country in countries)
            {
                int idCountry = _countriesContext.Countries.Where(p=>p.CountryName==country.CountryName).FirstOrDefault().Id;
                CountryCharacteristic newCountryCharacteristic = new CountryCharacteristic()
                {
                    Population = country.Population,
                    YearlyChange = country.YearlyChange,
                    NetChange = country.NetChange,
                    Density = country.Density,
                    LandArea = country.LandArea,
                    FertRate = country.FertRate,
                    MedAge = country.MedAge,
                    WorldShare = country.WorldShare,
                    CountryId=idCountry,
                    

                };
                await _countriesContext.AddAsync(newCountryCharacteristic);
            }
            await _countriesContext.SaveChangesAsync();
        }
    }
}
