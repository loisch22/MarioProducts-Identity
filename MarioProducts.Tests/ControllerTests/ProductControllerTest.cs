using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;
using MarioProducts.Controllers;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System;

namespace MarioProducts.Tests
{
    [TestClass]
    public class ProductControllerTest 
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        EFProductRepository db = new EFProductRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(mock => mock.Products).Returns(new Product[] {
                new Product(){Name = "Chili", Cost = 3, CountryOfOrigin = "Mexico", ProductId = 1},
                new Product(){Name = "Jelly Beans", Cost = 4, CountryOfOrigin = "USA", ProductId = 2},
                new Product(){Name = "Dried Seaweed", Cost = 3, CountryOfOrigin = "South Korea", ProductId = 3}
            }.AsQueryable());
        }

  
        [TestMethod]
        public void Mock_GetViewResultIndex_Test()
        {
            DbSetup();
			ProductController controller = new ProductController();

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_GetModelList_Test()
        {
            DbSetup();
            ViewResult indexView = new ProductController().Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
			ProductController controller = new ProductController(mock.Object);
            Product testProduct = new Product();
            testProduct.Name = "Dried Seaweed";
            testProduct.Cost = 3;
            testProduct.CountryOfOrigin = "South Korea";
            testProduct.ProductId = 3;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);
        }

		[TestMethod]
		public void DB_CreateNewProduct_Test()
		{
			ProductController controller = new ProductController(db);
			Product testProduct = new Product();
			testProduct.Name = "Chili";
			testProduct.Cost = 3;
			testProduct.CountryOfOrigin = "Mexico";
            testProduct.CreateDate = DateTime.Now;

			controller.Create(testProduct);
			var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

			CollectionAssert.Contains(collection, testProduct);
		}

        [TestMethod]
        public void DB_Edit_Test()
        {
            ProductController controller = new ProductController(db);
            Product testProduct = new Product();
			testProduct.Name = "Chili";
			testProduct.Cost = 3;
			testProduct.CountryOfOrigin = "Mexico";
            testProduct.CreateDate = DateTime.Now;

            controller.Create(testProduct);

            testProduct.Name = "Jalapenos";
            controller.Edit(testProduct);

            Assert.AreEqual("Jalapenos", testProduct.Name);
        }

        //public void Dispose()
        //{
        //    db.RemoveAll();
        //}
	}
}
