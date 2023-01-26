using Data.Models.Models;
using Data.ViewModels.AuthenticateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public interface IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public IEnumerable<User> GetAll();
        public User? GetById(int id);
        public void Delete(User user);
        public void Register(RegisterRequest model);
        public void Update(User user, UpdateRequest model);
    }
}
