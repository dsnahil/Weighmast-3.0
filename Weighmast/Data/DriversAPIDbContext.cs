using Microsoft.EntityFrameworkCore;
using Weighmast.Models;
namespace Weighmast.Data
{
    public class DriversAPIDbContext: DbContext
    {

        public DriversAPIDbContext(DbContextOptions<DriversAPIDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Driver> Drivers { get; set; }

        public static implicit operator DriversAPIDbContext(VehiclesAPIDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}
