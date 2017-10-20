using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarioProducts.Models;


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
   
        public ViewResult Index()
        {
            return View(reviewRepo.Reviews.Include(reviews => reviews.Products).ToList());
        }

        //public IActionResult Create()
        //{
        //    ViewBag.ProductId = new SelectList(reviewRepo.Products, "ProductId", "Name", "Cost", "CountryOfOrigin", "CreateDate");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Review review)
        //{
        //    reviewRepo.Save(review);
        //    return RedirectToAction("Index");
        //}
    }
}
