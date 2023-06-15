using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;

namespace StockWeb.Controllers
{
    public class ProductoController : Controller
    {
        private readonly StockWebFinalContext _context;
        public ProductoController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Producto
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Producto != null ?
                        View(await _context.Producto.ToListAsync()) :
                        Problem("Entity set 'StockWebContext.Producto'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // URL: /Producto/Crear
        public IActionResult Crear()
        {
            var proveedores = _context.Proveedor.ToList();
            ViewBag.Proveedores = proveedores;

            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = categorias;

            var marcas = _context.Marca.ToList();
            ViewBag.Marcas = marcas;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var proveedores = _context.Proveedor.ToList();
                ViewBag.Proveedores = proveedores;

                var marcas = _context.Marca.ToList();
                ViewBag.Marca = marcas;

                var categorias = _context.Categoria.ToList();
                ViewBag.Categoria = categorias;

                producto.FechaAlta = DateTime.Now;
                producto.Estado = true;

                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }


        // URL: /Producto/Editar

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            var proveedores = _context.Proveedor.ToList();
            ViewBag.Proveedores = proveedores;

            var categorias = _context.Categoria.ToList();
            ViewBag.Categorias = categorias;

            var marcas = _context.Marca.ToList();
            ViewBag.Marcas = marcas;

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var productoToUpdate = await _context.Producto.FirstOrDefaultAsync(c => c.Id == id);
                    productoToUpdate.Nombre = producto.Nombre;
                    // Mantener el valor original de FechaAlta
                    productoToUpdate.FechaAlta = producto.FechaAlta;
                    productoToUpdate.Estado = producto.Estado;
                    productoToUpdate.PrecioCompra = producto.PrecioCompra;

                    _context.Update(productoToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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

            return View(producto);
        }

        // URL: /Producto/Detalles
        [HttpGet]
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Producto == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        private bool ProductoExists(int id)
        {
            return _context.Categoria.Any(c => c.Id == id);
        }

        // URL: /Producto/BajoStock
        [HttpGet]
        public async Task<IActionResult> BajoStock()
        {
            var ProductoBajoStock = _context.Producto.Where(p => p.Stock <= p.StockMinimo && p.Estado).ToList();
            return View(ProductoBajoStock);
        }
    }
}
