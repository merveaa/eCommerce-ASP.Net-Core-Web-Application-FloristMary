using FloristMary.Infrastructure;
using FloristMary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloristMary.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context; //to connecto to the database 
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Products;
            return View(model);
        }

        
    }
}
