using Microsoft.EntityFrameworkCore;
using Weighmast.Models;

namespace Weighmast.Data
{
    public class VehiclesAPIDbContext : DbContext
    {
        public VehiclesAPIDbContext(DbContextOptions<VehiclesAPIDbContext> options) : base(options)
        {

        }


        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
