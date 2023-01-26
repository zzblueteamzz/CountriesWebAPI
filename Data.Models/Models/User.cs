using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models.Models
{
    public class User:BaseModel
    {
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string UserRole { get; set; }
        //public List<UserRole> UserRoles { get; set; }
    }
}
