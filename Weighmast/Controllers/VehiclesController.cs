using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {

        public VehiclesController(VehiclesAPIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public VehiclesAPIDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            return Ok(await DbContext.Vehicles.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle(AddVehicleRequest addVehicleRequest)
        {
            var vehicle = new Vehicle()
            {
                VehicleID = addVehicleRequest.VehicleID,
                VehicleNumber = addVehicleRequest.VehicleNumber,
                VehicleType = addVehicleRequest.VehicleType,
                TareWeight = addVehicleRequest.TareWeight,
                Notes = addVehicleRequest.Notes,
                AccountID = addVehicleRequest.AccountID,
                IsActive = addVehicleRequest.IsActive,
                
            };
            await DbContext.Vehicles.AddAsync(vehicle);
            await DbContext.SaveChangesAsync();

            return Ok(vehicle);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVehicles([FromRoute] int id)
        {
            var vehicle = await DbContext.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicle);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, UpdateVehicleRequest updateVehicleRequest)
        {
            var vehicle = await DbContext.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                vehicle.VehicleNumber = updateVehicleRequest.VehicleNumber;
                vehicle.VehicleType = updateVehicleRequest.VehicleType;
                vehicle.TareWeight = updateVehicleRequest.TareWeight;
                vehicle.Notes = updateVehicleRequest.Notes;
                vehicle.AccountID = updateVehicleRequest.AccountID;
                vehicle.IsActive = updateVehicleRequest.IsActive;


                await DbContext.SaveChangesAsync();

                return Ok(vehicle);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id)
        {
            var vehicle = await DbContext.Vehicles.FindAsync(id);

            if (vehicle != null)
            {
                DbContext.Remove(vehicle);
                await DbContext.SaveChangesAsync();
                return Ok(vehicle);
            }
            return NotFound();
        }
    }

}
