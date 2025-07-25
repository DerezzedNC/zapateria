using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoMaterialController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public PedidoMaterialController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoMaterial>>> GetPedidoMateriales()
        {
            return await _context.PedidoMaterial
                .Include(pm => pm.Pedido)
                .Include(pm => pm.Material)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoMaterial>> GetPedidoMaterial(int id)
        {
            var pedidoMaterial = await _context.PedidoMaterial
                .Include(pm => pm.Pedido)
                .Include(pm => pm.Material)
                .FirstOrDefaultAsync(pm => pm.IdPedidoMaterial == id);

            if (pedidoMaterial == null)
                return NotFound();

            return pedidoMaterial;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoMaterial>> PostPedidoMaterial(PedidoMaterial pedidoMaterial)
        {
            _context.PedidoMaterial.Add(pedidoMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidoMaterial), new { id = pedidoMaterial.IdPedidoMaterial }, pedidoMaterial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoMaterial(int id, PedidoMaterial pedidoMaterial)
        {
            if (id != pedidoMaterial.IdPedidoMaterial)
                return BadRequest();

            _context.Entry(pedidoMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PedidoMaterial.Any(e => e.IdPedidoMaterial == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoMaterial(int id)
        {
            var pedidoMaterial = await _context.PedidoMaterial.FindAsync(id);
            if (pedidoMaterial == null)
                return NotFound();

            _context.PedidoMaterial.Remove(pedidoMaterial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
