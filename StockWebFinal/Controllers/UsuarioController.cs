using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebFinal.Data;
using StockWebFinal.Models;

namespace StockWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly StockWebFinalContext _context;
        public UsuarioController(StockWebFinalContext context)
        {
            _context = context;
        }

        // URL: /Usuario
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Usuario != null ?
                        View(await _context.Usuario.ToListAsync()) :
                        Problem("Entity set 'StockWebContext.Usuario'  is null.");
        }

        [HttpGet]
        public async Task<IActionResult> Consultar(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // URL: /Usuario/Crear
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }


        // URL: /Usuario/Editar
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioToUpdate = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
                    usuarioToUpdate.NombreUsuario = usuario.NombreUsuario;
                    usuarioToUpdate.Clave = usuario.Clave;
                    usuarioToUpdate.Nombre = usuario.Nombre;
                    usuarioToUpdate.Apellido = usuario.Apellido;
                    usuarioToUpdate.Correo = usuario.Correo;
                    usuarioToUpdate.FechaNacimiento = usuario.FechaNacimiento;
                    // Mantener el valor original de FechaAlta
                    usuario.FechaAlta = usuarioToUpdate.FechaAlta;
                    usuarioToUpdate.Administrador = usuario.Administrador;
                    usuarioToUpdate.Estado = usuario.Estado;

                    _context.Update(usuarioToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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

            return View(usuario);
        }

        // URL: /Usuario/Detalles
        [HttpGet]
        public async Task<IActionResult> Detalles(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(u => u.Id == id);
        }

    }
}
