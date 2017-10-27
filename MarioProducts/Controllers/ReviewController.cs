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
    public class ReviewController : Controller
    {
        private readonly MarioProductsDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

        public ReviewController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MarioProductsDbContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_db = db;
		}
   
        public ViewResult Index(int id)
        {
            return View(_db.Reviews.Include(reviews => reviews.Products).ToList());
        }

        public IActionResult Create()
        {
			ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            _db.Reviews.Add(review);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
			ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            var thisReview = _db.Reviews.Include(x => x.Products)
                                       .FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisReview = _db.Reviews.Include(x => x.Products)
									   .FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
                                        
        }

		public IActionResult Delete(int id)
		{
            var thisReview = _db.Reviews.Include(x => x.Products)
									   .FirstOrDefault(x => x.ReviewId == id);
			return View(thisReview);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
			_db.Remove(thisReview);
			return RedirectToAction("Index");
		}
    }
}
