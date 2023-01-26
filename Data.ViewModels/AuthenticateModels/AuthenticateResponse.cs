using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.AuthenticateModels
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string UserRole { get; set; }
        public string Token { get; set; }
    }
}
