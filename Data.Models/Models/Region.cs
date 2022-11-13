using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class Region:BaseModel
    {
        public string Name { get; set; }
        public double Birtrate { get; set; }
        public double Deathrate { get; set; }
        
    }
}
