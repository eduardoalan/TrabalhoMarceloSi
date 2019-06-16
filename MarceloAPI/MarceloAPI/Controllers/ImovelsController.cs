using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarceloAPI.Models;

namespace MarceloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelsController : ControllerBase
    {
        private readonly TrabalhoMarceloSIContext _context;

        public ImovelsController(TrabalhoMarceloSIContext context)
        {
            _context = context;
        }

        // GET: api/Imovels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetImovel()
        {
            return await _context.Imovel.ToListAsync();
        }

        // GET: api/Imovels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imovel>> GetImovel(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            return imovel;
        }

        // PUT: api/Imovels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImovel(int id, Imovel imovel)
        {
            if (id != imovel.IdImovel)
            {
                return BadRequest();
            }

            _context.Entry(imovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImovelExists(id))
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

        // POST: api/Imovels
        [HttpPost]
        public async Task<ActionResult<Imovel>> PostImovel(Imovel imovel)
        {
            _context.Imovel.Add(imovel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImovelExists(imovel.IdImovel))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImovel", new { id = imovel.IdImovel }, imovel);
        }

        // DELETE: api/Imovels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imovel>> DeleteImovel(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }

            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();

            return imovel;
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.IdImovel == id);
        }
    }
}
