using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;

namespace StockWebFinal.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly StockWebFinalContext _context;
        public CategoriaController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Categoria
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Categoria != null ?
                        View(await _context.Categoria.ToListAsync()) :
                        Problem("Entity set 'StockWebContext.Categorias'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // URL: /Categoria/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.FechaAlta = System.DateTime.Now;
                categoria.Estado = true;
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // URL: /Categoria/Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var categoriaToUpdate = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);
                    categoriaToUpdate.Nombre = categoria.Nombre;
                    // Mantener el valor original de FechaAlta
                    categoria.FechaAlta = categoriaToUpdate.FechaAlta;
                    categoriaToUpdate.Estado = categoria.Estado;

                    _context.Update(categoriaToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        // URL: /Categoria/Detalles
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(c => c.Id == id);
        }
    }
}
