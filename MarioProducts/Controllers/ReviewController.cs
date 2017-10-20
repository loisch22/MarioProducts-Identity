using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;

namespace MarioProducts.Controllers
{
    public class ReviewController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }
    }
}
