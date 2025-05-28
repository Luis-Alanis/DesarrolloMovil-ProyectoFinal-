using GastosApi.Data;
using GastosApi.Models;
using Microsoft.AspNetCore.Mvc;

using GastosApi.Data;
using GastosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GastosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GastosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            return await _context.Gastos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> GetGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return NotFound();
            return gasto;
        }

        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGasto), new { id = gasto.Id }, gasto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasto(int id, Gasto gasto)
        {
            if (id != gasto.Id) return BadRequest();

            _context.Entry(gasto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return NotFound();

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
