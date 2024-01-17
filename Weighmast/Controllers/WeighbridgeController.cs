using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeighbridgeController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public WeighbridgeController(WeighmastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weighbridge>>> GetWeighbridge()
        {
            return await _context.Weighbridges.ToListAsync();
        }
   
        [HttpGet("{id}")]
        public async Task<ActionResult<Weighbridge>> GetWeighbridge(int id)
        {
            var weighbridge = await _context.Weighbridges.FindAsync(id);
            if (weighbridge == null)
            {
                return NotFound();
            }
            return Ok(weighbridge);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Weighbridge>>> AddWeighbridge(Weighbridge weighbridge)
        {
            _context.Weighbridges.Add(weighbridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeighbridge", new { id = weighbridge.WeighbridgeId }, weighbridge);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWeighbridge(int id)
        {
            var weighbridge = await _context.Weighbridges.FindAsync(id);
            if (weighbridge == null)
            {
                return NotFound();
            }

            _context.Weighbridges.Remove(weighbridge);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("{id}/activate")]
        public async Task<ActionResult> ActivateWeighbridge(int id)
        {
            var weighbridge = await _context.Weighbridges.FindAsync(id);
            if (weighbridge == null)
            {
                return NotFound();
            }
            if(weighbridge.IsActive == 1)
            {
                return BadRequest("Weighbridge is already active");
            }
            else
            {
                weighbridge.IsActive = 1;

            }
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Weighbridge>> UpdateWeighbridge(int id, Weighbridge updatedWeighbridge)
        {
            if (id != updatedWeighbridge.WeighbridgeId)
            {
                return BadRequest("Invalid ID");
            }

            var existingWeighbridge = await _context.Weighbridges.FindAsync(id);
            if (existingWeighbridge == null)
            {
                return NotFound("Weighbridge not found");
            }
            existingWeighbridge.ScaleName = updatedWeighbridge.ScaleName;
            existingWeighbridge.MaxCapacity = updatedWeighbridge.MaxCapacity;
            existingWeighbridge.IsActive = updatedWeighbridge.IsActive;
            existingWeighbridge.Unit = updatedWeighbridge.Unit;
            existingWeighbridge.ConnectionType = updatedWeighbridge.ConnectionType;
            existingWeighbridge.SerialPort = updatedWeighbridge.SerialPort;
            existingWeighbridge.DataBits = updatedWeighbridge.DataBits;
            existingWeighbridge.BaudRate = updatedWeighbridge.BaudRate;
            existingWeighbridge.StopBits = updatedWeighbridge.StopBits;
            existingWeighbridge.Parity = updatedWeighbridge.Parity;
            existingWeighbridge.TotalStringLength = updatedWeighbridge.TotalStringLength;
            existingWeighbridge.Format = updatedWeighbridge.Format;
            existingWeighbridge.StartStringCharacter = updatedWeighbridge.StartStringCharacter;
            existingWeighbridge.NewLine = updatedWeighbridge.NewLine;
            existingWeighbridge.IsDecimalCharacterInString = updatedWeighbridge.IsDecimalCharacterInString;
            existingWeighbridge.WeightStartFrom = updatedWeighbridge.WeightStartFrom;
            existingWeighbridge.ReverseString = updatedWeighbridge.ReverseString;
            existingWeighbridge.WeightLength = updatedWeighbridge.WeightLength;
            existingWeighbridge.Handshake = updatedWeighbridge.Handshake;
            existingWeighbridge.IndicatorId = updatedWeighbridge.IndicatorId;

            _context.Entry(existingWeighbridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeighbridgeExists(id))
                {
                    return NotFound("Weighbridge not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool WeighbridgeExists(int id)
        {
            return _context.Weighbridges.Any(d => d.WeighbridgeId == id);
        }
    }
}
