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
        public async Task<StatusCodeResult> Create(FromBody[] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Pais);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
        
        // PUT api/Pais/Edit
        [HttpPut("Edit")]
        public async Task<StatusCodeResult> Edit(FromBody[] Pais pais)
        {
        }
    }
}