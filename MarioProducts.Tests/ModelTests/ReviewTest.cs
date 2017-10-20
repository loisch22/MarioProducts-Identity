using System;
using MarioProducts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarioProducts.Tests
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void GetPropertiesTest()
        {
            var review = new Review(1, "Lois", "What an amazing product!", 4, 1);

            var id = review.ReviewId;
            var author = review.Author;
            var contentBody = review.ContentBody;
            var rating = review.Rating;
            var productId = review.ProductId;

            Assert.AreEqual(1, id);
            Assert.AreEqual("Lois", author);
            Assert.AreEqual("What an amazing product!", contentBody);
            Assert.AreEqual(4, rating);
            Assert.AreEqual(1, productId);
        }
    }
}
