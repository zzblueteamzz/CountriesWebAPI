using Data.Models.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public class DataService: IDataService
    {
        private CountriesContext CountriesContext { get; set; }
        public DataService(CountriesContext countriesContext)
        {
            CountriesContext = countriesContext;
        }

        public void SaveModelsToDatabase(List<PopulationModel> models)
        {
            CountriesContext.CountriesContext = models;
        }
        public void SaveUser(User user)
        {
            CountriesContext.Users.Add(user);
        }
    }
}
