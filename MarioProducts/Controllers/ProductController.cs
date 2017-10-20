using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            product.CreateDate = DateTime.Now;
            productRepo.Save(product);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            //ViewBag.reviews = new SelectList(productRepo.Reviews, "ReviewId", "Author", "ContentBody", "Rating", "ProductId");
            return View(thisProduct);
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct); 
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            productRepo.Edit(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
			var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
			var thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            productRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }
    }
}
