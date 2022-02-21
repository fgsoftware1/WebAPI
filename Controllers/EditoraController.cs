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

    public class EditoraController : Controller
    {
        private readonly projecto_webapiContext _context;

        public EditoraController(projecto_webapiContext context)
        {
            _context = context;
        }

        // GET api/Editora
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoras.ToListAsync());
        }

        // GET api/Editora/Details/
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
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

            return View(editora);
        }

        [HttpPost("Create")]
        // GET api/Editora/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
