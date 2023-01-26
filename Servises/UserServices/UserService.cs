using Authoriz;
using AutoMapper;
using Data.Context;
using Data.Models.Models;
using Data.ViewModels.AuthenticateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
    public class UserService: IUserService
    {
        private CountriesContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(CountriesContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User? user = _context.Users.SingleOrDefault(x => x.UserName == model.Username);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash)) return null;

            // authentication successful
            AuthenticateResponse response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateJwtToken(user);
            return response;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User? GetById(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public void Register(RegisterRequest model)
        {

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            user.UserRole = "User";
            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user, UpdateRequest model)
        {
            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
