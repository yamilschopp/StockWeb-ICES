using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;

namespace StockWeb.Controllers
{
    public class MarcaController : Controller
    {
        private readonly StockWebFinalContext _context;
        public MarcaController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Marca
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Marca != null ?
                        View(await _context.Marca.ToListAsync()) :
                        Problem("Entity set 'StockWebContext.Marcas'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // URL: /Marca/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Marca marca)
        {
            if (ModelState.IsValid)
            {
                marca.FechaAlta = System.DateTime.Now;
                marca.Estado = true;
                _context.Marca.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // URL: /Marca/Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var marcaToUpdate = await _context.Marca.FirstOrDefaultAsync(c => c.Id == id);
                    marcaToUpdate.Nombre = marca.Nombre;
                    // Mantener el valor original de FechaAlta
                    marca.FechaAlta = marcaToUpdate.FechaAlta;
                    marcaToUpdate.Estado = marca.Estado;

                    _context.Update(marcaToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.Id))
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

            return View(marca);
        }

        // URL: /Categoria/Detalles
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }
        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(c => c.Id == id);
        }
    }
}
