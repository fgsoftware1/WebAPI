using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_prog3.Models;

namespace WebAPI_prog3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LivroController : Controller
    {
        private readonly projecto_webapiContext _context;

        public LivroController(projecto_webapiContext context)
        {
            _context = context;
        }

        // GET api/Livro
        [HttpGet]
        public async Task<List<Livro>> GetAll_Livro()
        {
            var projecto_webapiContext = _context.Livros.Include(l => l.IdEditoraNavigation);
            return await projecto_webapiContext.ToListAsync();
        }

        // GET: Livro/Details
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.IdEditoraNavigation)
                .FirstOrDefaultAsync(m => m.IdLivro == id);
            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // GET api/Livro/Create
        [HttpGet("Create")]
        public async Task<StatusCodeResult> Create([FromBody] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        //PUT api/Livro/Edit
        [HttpPut("Edit")]
        public async Task<StatusCodeResult> Edit([FromBody] Livro livro)
        {
            if (livro.IdEditora == 0)
            {
                return NotFound();
            }

            var result = await _context.Livros.FindAsync(livro.IdLivro);

            if (result == null)
            {
                return NotFound();
            }

            result.Nome = livro.Nome;
            result.NumeroPaginas = livro.NumeroPaginas;
            result.Isbn = livro.Isbn;

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
    }
}
