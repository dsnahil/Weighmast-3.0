using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public GateController(WeighmastContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gate>>> GetGate()
        {
            return await _context.Gates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gate>> GetGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);


            if (gate == null)
            {
                return NotFound();
            }
            return gate;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Gate>>> AddGate(Gate gate)
        {
            gate.GateName = gate.GateName.Trim();

            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGate", new { id = gate.GateId }, gate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound();
            }

            _context.Gates.Remove(gate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("gate/{id}/activate")]
        public async Task<ActionResult<Gate>> ActivateGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound("Vehicle not found");
            }

            gate.Active = 1;
            _context.Entry(gate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateExists(id))
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
        [HttpPatch("gate/{id}/deactivate")]
        public async Task<ActionResult<Gate>> DeactivateGate(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate == null)
            {
                return NotFound("Vehicle not found");
            }

            gate.Active = 0;
            _context.Entry(gate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GateExists(id))
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

        private bool GateExists(int id)
        {
            return _context.Gates.Any(d => d.GateId == id);
        }
    }

}
