using Microsoft.AspNetCore.Mvc;
using StockWebFinal.Data;

namespace StockWebFinal.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly StockWebFinalContext _context;
        public ProvinciaController(StockWebFinalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
