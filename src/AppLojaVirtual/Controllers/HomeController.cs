using AppLojaVirtual.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppLojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produto.ToListAsync();
            return View(produtos);
        }
    }
}
