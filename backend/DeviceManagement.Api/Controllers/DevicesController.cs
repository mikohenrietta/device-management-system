using DeviceManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceContext _context;
    
        public DevicesController(DeviceContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if(device == null) return NotFound();
            return device;
        }
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDevice),new {id = device.DeviceID}, device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.DeviceID) return BadRequest();
            _context.Entry(device).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceID == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device is null) return NotFound();
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("with-users")]
        public async Task<IActionResult> GetDevicesWithUsers()
        {
            var devices = await _context.Devices.Include(d => d.Assignments)
                .ThenInclude(da => da.User)
                .Select(d => new
                {
                    Name = d.Name,
                    Manufacturer = d.Manufacturer,
                    Type = d.Type,
                    OperatingSystem = d.OperatingSystem,
                    OSVersion = d.OSVersion,
                    Processor = d.Processor,
                    RAMAmount = d.RAMAmount,
                    AssignedUser = d.Assignments.Select(da => da.User).FirstOrDefault()
                }).ToListAsync();
            return Ok(devices);
        }
    }
}
