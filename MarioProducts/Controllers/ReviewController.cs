using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarioProducts.Models;
using System.Diagnostics.Contracts;


namespace MarioProducts.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository reviewRepo;

        public ReviewController(IReviewRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.reviewRepo = new EFReviewRepository(); 
            }
            else
            {
                this.reviewRepo = thisRepo;    
            }
        }
   
        public ViewResult Index(int id)
        {
            return View(reviewRepo.Reviews.Include(reviews => reviews.Products).ToList());
        }

        public IActionResult Create()
        {
			ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisReview = reviewRepo.Reviews.Include(x => x.Products)
                                       .FirstOrDefault(x => x.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }
    }
}
