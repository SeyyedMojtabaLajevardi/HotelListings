using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListings.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
        }

        public DbSet<Country> countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }
    }
}
