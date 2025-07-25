using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CobroZapatoController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public CobroZapatoController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CobroZapato>>> GetCobrosZapato()
        {
            return await _context.CobrosZapato.ToListAsync(); // 🔴 Se quitó el Include
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CobroZapato>> GetCobroZapato(int id)
        {
            var cobro = await _context.CobrosZapato.FirstOrDefaultAsync(cz => cz.IdCobro == id); // 🔴 Se ajustó nombre
            if (cobro == null)
                return NotFound();
            return cobro;
        }

        [HttpPost]
        public async Task<ActionResult<CobroZapato>> PostCobroZapato(CobroZapato cobro)
        {
            _context.CobrosZapato.Add(cobro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCobroZapato), new { id = cobro.IdCobro }, cobro); // 🔴 Se ajustó nombre
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobroZapato(int id, CobroZapato cobro)
        {
            if (id != cobro.IdCobro) // 🔴 Se ajustó nombre
                return BadRequest();
            _context.Entry(cobro).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CobrosZapato.Any(e => e.IdCobro == id)) // 🔴 Se ajustó nombre
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobroZapato(int id)
        {
            var cobro = await _context.CobrosZapato.FindAsync(id);
            if (cobro == null)
                return NotFound();
            _context.CobrosZapato.Remove(cobro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
