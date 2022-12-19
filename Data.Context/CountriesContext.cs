using Data.Models;
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
        
    }
}