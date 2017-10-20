﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;

namespace MarioProducts.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepo;

        public ProductController(IProductRepository thisRepo = null)
        {
            if(thisRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = thisRepo;    
            }
        }

        public ViewResult Index()
        {
            return View(productRepo.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
            return RedirectToAction("Index");
        }
    }
}
