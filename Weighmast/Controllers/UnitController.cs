using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public UnitController(WeighmastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnit()
        {
            return await _context.Units.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound();
            }
            return unit;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Unit>>> AddUnit(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnit", new { id = unit.UnitId }, unit);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        //[Route("UpdateAllInformationById")]
        public async Task<IActionResult> UpdateAllInformationById(Vehicle vehicle)
        {
            var unit = await _context.Units.FindAsync(vehicle);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
