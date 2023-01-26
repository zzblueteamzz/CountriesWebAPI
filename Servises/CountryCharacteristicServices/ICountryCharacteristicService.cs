using Data.Models.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CountryCharacteristicServices
{
    public interface ICountryCharacteristicService<T>
    {
        public List<CountryCharacteristicViewModel> GetAll();
        public bool Create(T viewModel);
        public bool Update(T viewModel, string name);
        public bool Delete(int id);
    }
}
