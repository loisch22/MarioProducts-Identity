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
   
        public IActionResult Index(int id)
        {
            var allReviews = _db.Reviews.Include(reviews => reviews.Products).ToList();
            return Json(allReviews);
        }

        public IActionResult Create()
        {
			ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string author, string contentBody, int rating, int id)
        {
            var newReview = new Review(author, contentBody, rating, id);
            _db.Reviews.Add(newReview);
            _db.SaveChanges();
            return Json(newReview);
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
