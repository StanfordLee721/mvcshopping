
using Microsoft.AspNetCore.Mvc;

using mvcshopping.Models;

namespace shopping.Controllers
{
    public class ProductControllerOld : Controller
    {
        private readonly dbEntities _context;

        public ProductControllerOld(dbEntities context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

    }
}