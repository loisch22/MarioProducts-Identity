using System;
using MarioProducts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarioProducts.Tests
{
	[TestClass]
	public class ProductTest
	{
		[TestMethod]
		public void GetPropertiesTest()
		{
            var product = new Product("Chili", 3, "Mexico", 1);

            var name = product.Name;
            var cost = product.Cost;
            var countryOfOrigin = product.CountryOfOrigin;
            var id = product.ProductId;

            Assert.AreEqual("Chili", name);
            Assert.AreEqual(3, cost);
            Assert.AreEqual("Mexico", countryOfOrigin);
            Assert.AreEqual(1, id);
        }
	}
}
