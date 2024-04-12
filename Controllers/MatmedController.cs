using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apisaude.Context;
using apisaude.Models;

namespace apisaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatmedController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatmedController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Matmed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matmed>>> GetMatmeds()
        {
          if (_context.Matmeds == null)
          {
              return NotFound();
          }
            return await _context.Matmeds.ToListAsync();
        }

        // GET: api/Matmed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matmed>> GetMatmed(int id)
        {
          if (_context.Matmeds == null)
          {
              return NotFound();
          }
            var matmed = await _context.Matmeds.FindAsync(id);

            if (matmed == null)
            {
                return NotFound();
            }

            return matmed;
        }

        // PUT: api/Matmed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatmed(int id, Matmed matmed)
        {
            if (id != matmed.CodMatmed)
            {
                return BadRequest();
            }

            _context.Entry(matmed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatmedExists(id))
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

        // POST: api/Matmed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matmed>> PostMatmed(Matmed matmed)
        {
          if (_context.Matmeds == null)
          {
              return Problem("Entity set 'AppDbContext.Matmeds'  is null.");
          }
            _context.Matmeds.Add(matmed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatmed", new { id = matmed.CodMatmed }, matmed);
        }

        // DELETE: api/Matmed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatmed(int id)
        {
            if (_context.Matmeds == null)
            {
                return NotFound();
            }
            var matmed = await _context.Matmeds.FindAsync(id);
            if (matmed == null)
            {
                return NotFound();
            }

            _context.Matmeds.Remove(matmed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatmedExists(int id)
        {
            return (_context.Matmeds?.Any(e => e.CodMatmed == id)).GetValueOrDefault();
        }
    }
}
