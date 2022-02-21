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

        // GET: Cidades
        public async Task<List<Cidade>> GetAll_Cidade()
        {
            var projecto_webapiContext = _context.Cidades.Include(c => c.IdPaisNavigation);
            return await projecto_webapiContext.ToListAsync();
        }

        // GET: Cidades/Details/5
        public async Task<object> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.IdPaisNavigation)
                .FirstOrDefaultAsync(m => m.IdCidade == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }
    }
}
