using Data.Models;
using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServices
{
    public interface IDataService
    {

        public void SaveModelsToDatabase(List<PopulationModel> models);

        public void SaveUser(User user);
       
    }
}
