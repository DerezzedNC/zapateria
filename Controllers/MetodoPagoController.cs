using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public MetodoPagoController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodosPago()
        {
            return await _context.MetodosPago.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoPago>> GetMetodoPago(int id)
        {
            var metodoPago = await _context.MetodosPago.FindAsync(id);

            if (metodoPago == null)
            {
                return NotFound();
            }

            return metodoPago;
        }

        [HttpPost]
        public async Task<ActionResult<MetodoPago>> PostMetodoPago(MetodoPago metodoPago)
        {
            _context.MetodosPago.Add(metodoPago);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMetodoPago), new { id = metodoPago.IdMetodoPago }, metodoPago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoPago(int id, MetodoPago metodoPago)
        {
            if (id != metodoPago.IdMetodoPago)
                return BadRequest();

            _context.Entry(metodoPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MetodosPago.Any(e => e.IdMetodoPago == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoPago(int id)
        {
            var metodoPago = await _context.MetodosPago.FindAsync(id);
            if (metodoPago == null)
                return NotFound();

            _context.MetodosPago.Remove(metodoPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
