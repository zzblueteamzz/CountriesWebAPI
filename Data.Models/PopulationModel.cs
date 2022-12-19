using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PopulationModel:BaseModel
    {
        public string CountryName { get; set; }
        public int Population { get; set; }
        public string YearlyChange { get; set; }

        public int NetChange { get; set; }
        public int Density { get; set; }
    }
}
