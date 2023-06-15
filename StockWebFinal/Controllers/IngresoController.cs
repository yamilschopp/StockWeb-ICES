using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;
using System.Text;

namespace StockWebFinal.Controllers
{
    public class IngresoController : Controller
    {
        private readonly StockWebFinalContext _context;

        public IngresoController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Ingreso
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Egreso != null ?
                        View(await _context.Ingreso.ToListAsync()) :
                        Problem("Entity set 'StockWebFinalContext.Ingreso'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Ingreso == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingreso.FirstOrDefaultAsync(i => i.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

        // GET: /Ingreso/Crear
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
        public async Task<IActionResult> SumarCantidad(Ingreso ingreso)
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

                ingreso.Fecha = System.DateTime.Now;
                _context.Ingreso.Add(ingreso);


                var producto = await _context.Producto.FindAsync(ingreso.Producto_Id);
                if (producto != null)
                {
                    producto.PrecioCompra = ingreso.PrecioCompra;
                    producto.Stock += ingreso.Cantidad;
                    _context.Producto.Update(producto);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            return View(ingreso);
        }

        // GET: /Ingreso/Detalles
        [HttpGet]
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Ingreso == null)
            {
                return NotFound();
            }

            var ingreso = await _context.Ingreso.FirstOrDefaultAsync(i => i.Id == id);
            if (ingreso == null)
            {
                return NotFound();
            }

            return View(ingreso);
        }

    }
}

