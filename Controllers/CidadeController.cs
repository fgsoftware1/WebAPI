using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI_prog3.Models;

namespace WebAPI_prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CidadeController : Controller
    {
        private readonly projecto_webapiContext _context;

        public CidadeController(projecto_webapiContext context)
        {
            _context = context;
        }

        //GET api/Cidade
        [HttpGet]
        public async Task<List<Cidade>> GetAll_Cidade()
        {
            return await _context.Cidades.ToListAsync();
        }

        // GET api/Cidade/Details
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .FirstOrDefaultAsync(m => m.IdCidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // POST api/Cidade/Create
        [HttpPost("Create")]
        public async Task<StatusCodeResult> Create([FromBody] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        //PUT api/Cidade/Edit
        [HttpPut("Edit")]
        public async Task<StatusCodeResult> Edit([FromBody] Cidade cidade)
        {
            if (cidade.IdCidade == 0)
            {
                return NotFound();
            }

            var result = await _context.Cidades.FindAsync(cidade.IdCidade);

            if (result == null)
            {
                return NotFound();
            }

            result.Nome = cidade.Nome;
            result.Regiao = cidade.Regiao;

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
        public async Task<StatusCodeResult> Delete_cidade(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FirstOrDefaultAsync(m => m.IdCidade == id);

            if (cidade == null)
            {
                return NotFound();
            }

            _context.Remove(cidade);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
