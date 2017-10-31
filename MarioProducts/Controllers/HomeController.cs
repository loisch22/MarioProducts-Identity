using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using MarioProducts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarioProducts.Controllers
{
    public class HomeController : Controller
    {
        private MarioProductsDbContext _db = new MarioProductsDbContext();

        public IActionResult Index()
        {
            List<Product> mostRecent = _db.Products.OrderByDescending(x => x.ProductId).Take(3).ToList();
            List<Product> bestRated = _db.Products.Include(x => x.Reviews).OrderByDescending(r => r.AverageRating()).Take(3).ToList();

            ViewData["mostRecent"] = mostRecent;
            ViewData["bestRated"] = bestRated;

            return View();
        }

    }
}
