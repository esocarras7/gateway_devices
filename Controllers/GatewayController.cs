using Microsoft.AspNetCore.Mvc;
using gateway_devices.Model;
using gateway_devices.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace gateway_devices.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/gateway")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly GatewayDbContext _context;

        public GatewayController(GatewayDbContext context)
        {
            _context = context;
        }

        // Returning a list of gateways
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gateway>>> GetGateways()
        {
            return await _context.Gateways
            .Include(d => d.Devices)
            .ToListAsync();
        }

        //Returnig a single gateway
        [HttpGet("{id}")]
        public async Task<ActionResult<Gateway>> GetSingleGateway(long id)
        {
            var gateway = await _context.Gateways
            .Include(d => d.Devices)
            .FirstOrDefaultAsync(g => g.Id == id);

            if (gateway == null)
            {
                return NotFound();
            }

            return Ok(gateway);
        }

        [HttpPost]
        public async Task<ActionResult<Gateway>> AddGateway([FromBody] Gateway gateway)
        {
            List<Device> devices = new List<Device>();

            if (gateway.Devices.Count > 10)
            {
                return BadRequest();

            }

            devices = gateway.Devices.ToList<Device>();

            var newGateway = new Gateway
            {
                SerialNumber = gateway.SerialNumber,
                Name = gateway.Name,
                IPAddress = gateway.IPAddress,
                Devices = devices
            };

            _context.Gateways.Add(newGateway);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingleGateway), new
            {
                Id = newGateway.Id
            }, newGateway);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Gateway>> DeleteGateway(long id)
        {
            var tempGateway = await _context.Gateways.FindAsync(id);

            if (tempGateway == null)
            {
                return NotFound();
            }

            _context.Gateways.Remove(tempGateway);
            await _context.SaveChangesAsync();

            return tempGateway;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGateway(long id, [FromBody] JsonPatchDocument<Gateway> patchDoc)
        {
            if (patchDoc != null)
            {
                var gateway = _context.Gateways.Include(g => g.Devices).FirstOrDefault(g => g.Id == id);

                if (gateway == null)
                {
                    return NotFound();
                }

                if (patchDoc.Operations[0].op == "add" && gateway.Devices.Count == 10)
                {
                    return BadRequest(error: "The number of devices cannot exceed 10.");
                }

                patchDoc.ApplyTo(gateway, ModelState);

                if (!TryValidateModel(gateway))
                {
                    return BadRequest(ModelState);
                }

                await _context.SaveChangesAsync();

                return new ObjectResult(gateway);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Helper methods
        public bool GatewayExists(long id)
        {
            return _context.Gateways.Any(g => g.Id == id);
        }
    }
}