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

    public class EditorasController : Controller
    {
        private readonly projecto_webapiContext _context;

        public EditorasController(projecto_webapiContext context)
        {
            _context = context;
        }

        // GET api/Editoras
        [HttpGet]
        public async Task<List<Editora>> GetAll_Editora()
        {
            return await _context.Editoras.ToListAsync();
        }

        // GET api/Editoras/Details/
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editora = await _context.Editoras
                .FirstOrDefaultAsync(m => m.IdEditora == id);
            if (editora == null)
            {
                return NotFound();
            }

            return editora;
        }


        // GET api/Editoras/Create
        [HttpPost("Create")]
        public async Task<StatusCodeResult> Create([FromBody] Editora editora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editora);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("Edit")]
        //PUT api/Editoras/Edit
        public async Task<StatusCodeResult> Edit([FromBody] Editora editora)
        {
            if(editora.IdEditora == 0)
            {
                return NotFound();
            }

            var result = await _context.Editoras.FindAsync(editora.IdEditora);

            if(result == null)
            {
                return NotFound();
            }

            result.Nome = editora.Nome;
            result.Ativo = editora.Ativo;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);

                    await _context.SaveChangesAsync();

                    return Ok();
                }catch(DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }
    }
}
