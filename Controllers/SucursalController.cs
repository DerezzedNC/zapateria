using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public SucursalController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
                return NotFound();
            return sucursal;
        }

        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.IdSucursal }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
                return BadRequest();
            _context.Entry(sucursal).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Sucursales.Any(e => e.IdSucursal == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
                return NotFound();
            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
