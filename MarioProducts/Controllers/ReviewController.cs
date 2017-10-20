using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
