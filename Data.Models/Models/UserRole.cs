using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class UserRole:BaseModel
    {
        public string RoleName { get; set; }
        public List<User> Users { get; set; }
    }
}
