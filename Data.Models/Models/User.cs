using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class User:BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
