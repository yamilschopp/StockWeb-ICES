using Microsoft.AspNetCore.Mvc;
using StockWebFinal.Data;

namespace StockWebFinal.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly StockWebFinalContext _context;
        public LocalidadController(StockWebFinalContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
