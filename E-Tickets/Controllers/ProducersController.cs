using E_Tickets.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Tickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //var allProducers = await _context.Producers.ToListAsync();
            var allProducers = _context.Producers.ToList();

            return View(allProducers);
        }
    }
}
