using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_prog3.Models;

namespace WebAPI_prog3.Controllers
{
    //caminho genérico para invocar um controlador
    [ApiController]
    [Route("api/[controller]")]

    public class EditorasController : Controller
    {
        private readonly projecto_webapiContext _context;

        public EditorasController(projecto_webapiContext context)
        {
            _context = context;
        }

        //GET api/Editoras
        [HttpGet]
        public async Task<List<Editora>> GetAll_Editoras()
        {
            return await _context.Editoras.ToListAsync();
        }

        //GET api/Editoras/Details
        [HttpGet("Details/{id}")]
        public async Task<object> Details(int id)
        {
            //id vazio?
            if (id == null)
            {
                return NotFound();
            }
            //consulta dos dados na BD com a função FirstOrDefaultAsync
            var editora = await _context.Editoras.FirstOrDefaultAsync(m => m.IdEditora == id);

            //nulo ou vazio? "Not Found"
            if (editora == null)
            {
                return NotFound();
            }

            //retorna se encontrar dados
            return editora;
        }

        //POST api/Editoras/Create
        [HttpPost("Create")]
        public async Task<StatusCodeResult> Create([FromBody] Editora editora)
        {
            return Ok();
        }
    }
}
