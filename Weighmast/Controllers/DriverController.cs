using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public DriverController(WeighmastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDriver()
        {
            return await _context.Drivers.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }
            return driver;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Driver>>> AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.DriverId }, driver);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Driver>> UpdateDriver(int id, Driver updatedDriver)
        {
            if (id != updatedDriver.DriverId)
            {
                return BadRequest("Invalid ID");
            }

            var existingDriver = await _context.Drivers.FindAsync(id);
            if (existingDriver == null)
            {
                return NotFound("Driver not found");
            }
            existingDriver.FirstName = updatedDriver.FirstName; 
            existingDriver.LastName = updatedDriver.LastName;
            existingDriver.AccountId = updatedDriver.AccountId;
            existingDriver.Active = updatedDriver.Active;
           
            _context.Entry(existingDriver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        [HttpPatch("driver/{id}/activate")]
        public async Task<ActionResult<Driver>> ActivateDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound("Driver not found");
            }

            driver.Active = 1;
            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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
        [HttpPatch("driver/{id}/deactivate")]
        public async Task<ActionResult<Driver>> DeactivateDriver(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound("Driver not found");
            }

            driver.Active = 0;
            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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
        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(d => d.DriverId == id);
        }


    }
}