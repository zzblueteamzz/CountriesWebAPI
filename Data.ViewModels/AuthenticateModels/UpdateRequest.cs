using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.AuthenticateModels
{
    public class UpdateRequest
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
    }
}
