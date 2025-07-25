using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZapatoController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public ZapatoController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zapato>>> GetZapatos()
        {
            return await _context.Zapatos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zapato>> GetZapato(int id)
        {
            var zapato = await _context.Zapatos.FindAsync(id);
            if (zapato == null)
                return NotFound();
            return zapato;
        }

        [HttpPost]
        public async Task<ActionResult<Zapato>> PostZapato(Zapato zapato)
        {
            _context.Zapatos.Add(zapato);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetZapato), new { id = zapato.IdZapato }, zapato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutZapato(int id, Zapato zapato)
        {
            if (id != zapato.IdZapato)
                return BadRequest();
            _context.Entry(zapato).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Zapatos.Any(e => e.IdZapato == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZapato(int id)
        {
            var zapato = await _context.Zapatos.FindAsync(id);
            if (zapato == null)
                return NotFound();
            _context.Zapatos.Remove(zapato);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
