using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CountryServices
{
    public interface ICountryService<T>
    {
      
        public bool Create(T viewModel);
        public bool Update(T viewModel);
        public bool Delete(int id);

    }
}
