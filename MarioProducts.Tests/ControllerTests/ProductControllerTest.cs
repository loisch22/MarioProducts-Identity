using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using MarioProducts.Models;
using MarioProducts.Controllers;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace MarioProducts.Tests
{
    [TestClass]
    public class ProductControllerTest : IDisposable
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
        public void DB_CreateNewProduct_Test()
        {
            ProductController controller = new ProductController(db);
            Product testProduct = new Product();
            testProduct.Name = "Chili";
            testProduct.Cost = 3;
            testProduct.CountryOfOrigin = "Mexico";

            controller.Create(testProduct);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);
        }

    }
}
