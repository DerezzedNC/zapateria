using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZapateriaAPI.Models;

namespace ZapateriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly ZapateriaDbContext _context;

        public MaterialController(ZapateriaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMateriales()
        {
            return await _context.Materiales.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Materiales.FindAsync(id);
            if (material == null)
                return NotFound();
            return material;
        }

        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(Material material)
        {
            _context.Materiales.Add(material);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMaterial), new { id = material.IdMaterial }, material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material material)
        {
            if (id != material.IdMaterial)
                return BadRequest();
            _context.Entry(material).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Materiales.Any(e => e.IdMaterial == id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materiales.FindAsync(id);
            if (material == null)
                return NotFound();
            _context.Materiales.Remove(material);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
} 