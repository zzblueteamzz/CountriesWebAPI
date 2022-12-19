using Data.Models;
using Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Reflection;

namespace Data.Context
{
    public class CountriesContext : DbContext
    {
        public CountriesContext(DbContextOptions options) : base(options)
        {
            
        }

        
        public DbSet<PopulationModel> PopulationModel { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; }
        
    }
}