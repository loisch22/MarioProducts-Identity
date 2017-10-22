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
    public class ReviewControllerTest : IDisposable
	{
		Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

		EFReviewRepository db = new EFReviewRepository(new TestDbContext());
        EFProductRepository db2 = new EFProductRepository(new TestDbContext());

		private void DbSetup()
		{
			mock.Setup(mock => mock.Reviews).Returns(new Review[] {
				new Review(){ReviewId = 1, Author = "Lois", ContentBody = "What a wonderful product!", Rating = 4, ProductId = 1},
				new Review(){ReviewId = 2, Author = "Sam", ContentBody = "Decent product, poor packaging", Rating = 2, ProductId = 2},
				new Review(){ReviewId = 3, Author = "Chad", ContentBody = "Perfectly crisp and salty", Rating = 5, ProductId = 3}
			}.AsQueryable());
		}

        public void Dispose()
        {
            db.RemoveAll();
       
        }

		[TestMethod]
		public void Mock_GetViewResultIndex_Test()
		{
			DbSetup();
			ReviewController controller = new ReviewController();

			var result = controller.Index();

			Assert.IsInstanceOfType(result, typeof(ActionResult));
		}

		[TestMethod]
		public void Mock_GetModelList_Test()
		{
			DbSetup();
			ViewResult indexView = new ReviewController().Index() as ViewResult;

			var result = indexView.ViewData.Model;

			Assert.IsInstanceOfType(result, typeof(List<Review>));
		}

		[TestMethod]
		public void Mock_ConfirmEntry_Test()
		{
			DbSetup();
			ReviewController controller = new ReviewController(mock.Object);
			Review testReview = new Review();
            testReview.ReviewId = 1;
			testReview.Author = "Lois";
            testReview.ContentBody = "What a wonderful product!";
            testReview.Rating = 4;
            testReview.ProductId = 1;

			ViewResult indexView = controller.Index() as ViewResult;
			var collection = indexView.ViewData.Model as List<Review>;

			CollectionAssert.Contains(collection, testReview);
		}

		[TestMethod]
		public void DB_CreateNewReview_Test()
		{
			ReviewController controller = new ReviewController(db);
			Review testReview = new Review();
			testReview.ReviewId = 1;
			testReview.Author = "Matt";
			testReview.ContentBody = "Best chili I've ever had!";
			testReview.Rating = 4;
			testReview.ProductId = 1;

			controller.Create(testReview);
			var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

			CollectionAssert.Contains(collection, testReview);
		}

		[TestMethod]
		public void DB_Edit_Test()
		{
			ReviewController controller = new ReviewController(db);
			Review testReview = new Review();
			testReview.ReviewId = 1;
			testReview.Author = "Matt";
			testReview.ContentBody = "Best chili I've ever had!";
			testReview.Rating = 4;
			testReview.ProductId = 1;

			controller.Create(testReview);

			testReview.Author = "Matthew";
			controller.Edit(testReview);

			Assert.AreEqual("Matthew", testReview.Author);
		}
	}
}
