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
    public class ImobiliariasController : ControllerBase
    {
        private readonly TrabalhoMarceloSIContext _context;

        public ImobiliariasController(TrabalhoMarceloSIContext context)
        {
            _context = context;
        }

        // GET: api/Imobiliarias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imobiliaria>>> GetImobiliaria()
        {
            return await _context.Imobiliaria.ToListAsync();
        }

        // GET: api/Imobiliarias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imobiliaria>> GetImobiliaria(int id)
        {
            var imobiliaria = await _context.Imobiliaria.FindAsync(id);

            if (imobiliaria == null)
            {
                return NotFound();
            }

            return imobiliaria;
        }

        // PUT: api/Imobiliarias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImobiliaria(int id, Imobiliaria imobiliaria)
        {
            if (id != imobiliaria.IdImobiliaria)
            {
                return BadRequest();
            }

            _context.Entry(imobiliaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImobiliariaExists(id))
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

        // POST: api/Imobiliarias
        [HttpPost]
        public async Task<ActionResult<Imobiliaria>> PostImobiliaria(Imobiliaria imobiliaria)
        {
            _context.Imobiliaria.Add(imobiliaria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ImobiliariaExists(imobiliaria.IdImobiliaria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetImobiliaria", new { id = imobiliaria.IdImobiliaria }, imobiliaria);
        }

        // DELETE: api/Imobiliarias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imobiliaria>> DeleteImobiliaria(int id)
        {
            var imobiliaria = await _context.Imobiliaria.FindAsync(id);
            if (imobiliaria == null)
            {
                return NotFound();
            }

            _context.Imobiliaria.Remove(imobiliaria);
            await _context.SaveChangesAsync();

            return imobiliaria;
        }

        private bool ImobiliariaExists(int id)
        {
            return _context.Imobiliaria.Any(e => e.IdImobiliaria == id);
        }
    }
}
