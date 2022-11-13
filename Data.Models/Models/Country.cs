using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class Country:BaseModel
    {
        public string Name { get; set; }
        public long Area { get; set; }
        public long Population { get; set; }
        public int RegionId { get; set; }
        public Region Regions { get; set; }
    }
}
