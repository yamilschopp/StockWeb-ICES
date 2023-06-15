using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;
using System.Text;

namespace StockWebFinal.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly StockWebFinalContext _context;

        public ProveedorController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Proveedor
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Proveedor != null ?
                        View(await _context.Proveedor.ToListAsync()) :
                        Problem("Entity set 'StockWebContext.Proveedor'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // URL: /Proveedor/Crear
        public IActionResult Crear()
        {
            var provincias = _context.Provincia.ToList();
            ViewBag.Provincias = provincias;

            var localidades = _context.Localidad.ToList();
            ViewBag.Localidades = localidades;

            return View();
        }

        [HttpPost]
        public IActionResult CargarLocalidades(int provinciaId)
        {
            var localidades = _context.Localidad.Where(l => l.Provincia_Id == provinciaId).ToList();

            var options = new StringBuilder();
            options.Append("<option value=''>Seleccione una localidad</option>");

            foreach (var localidad in localidades)
            {
                options.AppendFormat("<option value='{0}'>{1}</option>", localidad.Id, localidad.Nombre);
            }

            return Content(options.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                var provincias = _context.Provincia.ToList();

                ViewBag.Provincias = provincias;
                ViewBag.Localidades = new List<Localidad>();

                proveedor.FechaAlta = System.DateTime.Now;
                proveedor.Estado = true;

                _context.Proveedor.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(proveedor);
        }

        // URL: /Proveedor/Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            var provincias = _context.Provincia.ToList();

            ViewBag.Provincias = provincias;
            ViewBag.Localidades = new List<Localidad>();

            return View(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var proveedorToUpdate = await _context.Proveedor.FirstOrDefaultAsync(c => c.Id == id);
                    proveedorToUpdate.CuilCuit = proveedor.CuilCuit;
                    proveedorToUpdate.Direccion = proveedor.Direccion;
                    proveedorToUpdate.Provincia_Id = proveedor.Provincia_Id;
                    proveedorToUpdate.Localidad_Id = proveedor.Localidad_Id;
                    proveedorToUpdate.Telefono = proveedor.Telefono;
                    proveedorToUpdate.Correo = proveedor.Correo;
                    proveedorToUpdate.Denominacion = proveedor.Denominacion;
                    proveedorToUpdate.Estado = proveedor.Estado;
                    // Mantener el valor original de FechaAlta
                    proveedor.FechaAlta = proveedorToUpdate.FechaAlta;

                    _context.Update(proveedorToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.Id))
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

            var provincias = _context.Provincia.ToList();
            var localidades = _context.Localidad.ToList();

            ViewBag.Provincias = provincias;
            ViewBag.Localidades = localidades;

            return View(proveedor);
        }

        // URL: /Proveedor/Detalles
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.FirstOrDefaultAsync(p => p.Id == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            var provincias = _context.Provincia.ToList();

            ViewBag.Provincias = provincias;
            ViewBag.Localidades = new List<Localidad>();

            return View(proveedor);
        }
        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(p => p.Id == id);
        }
    }
}
