using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CountryCharacteristicServices
{
    public interface ICountryCharacteristicService<T>
    {
        public bool Create(T viewModel);
        public bool Update(T viewModel);
        public bool Delete(int id);
    }
}
