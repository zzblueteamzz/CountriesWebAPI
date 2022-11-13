using Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class CountriesContext : DbContext
    {
        public CountriesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

    }
}