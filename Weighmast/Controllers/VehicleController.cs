using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public VehicleController(WeighmastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        {
            return await _context.Vehicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);


            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Vehicle>>> AddVehicle(Vehicle vehicle)
        {
            vehicle.VehicleNumber = vehicle.VehicleNumber.Trim();

            vehicle.TareWeight=decimal.Parse(vehicle.TareWeight.ToString().Replace(" ", ""));



            string decimalAsString = vehicle.TareWeight.ToString().Trim();
            string digitsOnly = RemoveNonDigits(decimalAsString);

            static string RemoveNonDigits(string input)
            {
                // Use a regular expression to remove non-digit characters
                return Regex.Replace(input, @"[^\d]", "");
            }

            if (!string.IsNullOrEmpty(vehicle.VehicleNumber))
                vehicle.VehicleNumber = vehicle.VehicleNumber.Replace(" ", "").ToUpper();


            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleId }, vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("vehicle/{id}/activate")]
        public async Task<ActionResult<Vehicle>> ActivateVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }

            vehicle.IsActive = 1;
            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPatch("vehicle/{id}/deactivate")]
        public async Task<ActionResult<Vehicle>> DeactivateVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }
            if (vehicle.IsActive == 1)
            {
                return BadRequest("Weighbridge is already active");
            }
            else
            {
                vehicle.IsActive = 1;

            }
            vehicle.IsActive = 0;
            _context.Entry(vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(v => v.VehicleId == id);
        }
    }
}