using Kindergarten1;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace KindergartenWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetiController : ControllerBase
    {
        private readonly DSADEntities _context;

        public DetiController(DSADEntities context)
        {
            _context = context;
        }

        // GET: api/Deti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deti>>> GetDeti()
        {
            return await _context.Deti.ToListAsync();
        }

        // GET: api/Deti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deti>> GetDeti(int id)
        {
            var deti = await _context.Deti.FindAsync(id);

            if (deti == null)
            {
                return NotFound();
            }

            return deti;
        }

        // POST: api/Deti
        [HttpPost]
        public async Task<ActionResult<Deti>> PostDeti(Deti deti)
        {
            _context.Deti.Add(deti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeti", new { id = deti.Id_dati }, deti);
        }

        // PUT: api/Deti/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeti(int id, Deti deti)
        {
            if (id != deti.Id_dati)
            {
                return BadRequest();
            }

            _context.Entry(deti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Deti.Any(e => e.Id_dati == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Deti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeti(int id)
        {
            var deti = await _context.Deti.FindAsync(id);
            if (deti == null)
            {
                return NotFound();
            }

            _context.Deti.Remove(deti);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}