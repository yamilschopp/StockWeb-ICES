using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;

namespace StockWebFinal.Controllers
{
    public class EgresoController : Controller
    {
        private readonly StockWebFinalContext _context;

        public EgresoController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Egreso
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Egreso != null ?
                        View(await _context.Egreso.ToListAsync()) :
                        Problem("Entity set 'StockWebFinalContext.Egreso'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Egreso == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egreso.FirstOrDefaultAsync(e => e.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // GET: /Egreso/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            var marcas = _context.Marca.ToList();
            ViewBag.Marcas = marcas;

            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = categorias;

            var productos = _context.Producto.ToList();
            ViewBag.Productos = productos;

            var usuarios = _context.Usuario.ToList();
            ViewBag.Usuarios = usuarios;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RestarCantidad(Egreso egreso)
        {
            if (ModelState.IsValid)
            {
                var marcas = _context.Marca.ToList();
                ViewBag.Marcas = marcas;

                var categorias = _context.Categoria.ToList();
                ViewBag.Categorias = categorias;

                var productos = _context.Producto.ToList();
                ViewBag.Productos = productos;

                var usuarios = _context.Usuario.ToList();
                ViewBag.Usuarios = usuarios;

                egreso.Fecha = System.DateTime.Now;
                _context.Egreso.Add(egreso);


                var producto = await _context.Producto.FindAsync(egreso.Producto_Id);
                if (producto != null)
                {
                    producto.Stock -= egreso.Cantidad;
                    _context.Producto.Update(producto);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(egreso);
        }

        // GET: /Engreso/Detalles
        [HttpGet]
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Egreso == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egreso.FirstOrDefaultAsync(e => e.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }
    }
}
