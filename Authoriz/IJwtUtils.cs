using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authoriz
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
    }
}
