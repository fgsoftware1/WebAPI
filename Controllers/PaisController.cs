using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_prog3.Models;

namespace WebAPI_prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PaisController : Controller
    {
        private readonly projecto_webapiContext _context;

        public PaisController(projecto_webapiContext context)
        {
            _context = context;
        }

        //GET api/Pais
        [HttpGet]
        public async Task<List<Pais>> GetAll_Pais()
        {
            return await _context.Pais.ToListAsync();
        }

        // GET api/Pais/Details
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Pais
                .FirstOrDefaultAsync(m => m.IdPais == id);
            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // POST api/Pais/Create
        [HttpPost("Create")]
        public async Task<StatusCodeResult> Create([FromBody] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pais);

                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

        //PUT api/Pais/Edit
        [HttpPut("Edit")]
        public async Task<StatusCodeResult> Edit([FromBody] Pais pais)
        {
            if (pais.IdPais == 0)
            {
                return NotFound();
            }

            var result = await _context.Pais.FindAsync(pais.IdPais);

            if (result == null)
            {
                return NotFound();
            }

            result.Populacao = pais.Populacao;
            result.Moeda = pais.Moeda;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        //DELETE api/Pais/Delete
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete_pais(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Pais.FirstOrDefaultAsync(m => m.IdPais == id);

            if (pais == null)
            {
                return NotFound();
            }

            _context.Remove(pais);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}