using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MarioProducts.Models;
using System.Diagnostics.Contracts;

namespace MarioProducts.Controllers
{
    public class ProductController : Controller
    {
		private readonly MarioProductsDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public ProductController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MarioProductsDbContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
		}

        public ViewResult Index()
        {
            return View(_db.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.CreateDate = DateTime.Now;
            _db.Products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisProduct = _db.Products.FirstOrDefault(x => x.ProductId == id);
            //ViewBag.reviews = new SelectList(productRepo.Reviews, "ReviewId", "Author", "ContentBody", "Rating", "ProductId");
            return View(thisProduct);
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = _db.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct); 
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
			var thisProduct = _db.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
			var thisProduct = _db.Products.FirstOrDefault(x => x.ProductId == id);
            _db.Remove(thisProduct);
            return RedirectToAction("Index");
        }
    }
}
