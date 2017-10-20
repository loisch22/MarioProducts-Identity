using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioProducts.Models
{
	public class EFProductRepository : IProductRepository
	{
		MarioProductsDbContext db = new MarioProductsDbContext();

		public EFProductRepository(MarioProductsDbContext connection = null)
		{
			if (connection == null)
			{
				this.db = new MarioProductsDbContext();
			}
			else
			{
				this.db = connection;
			}
		}

		public IQueryable<Product> Products
		{ get { return db.Products; } }

		public IQueryable<Review> Reviews
		{ get { return db.Reviews; } }

		public Product Save(Product product)
		{
			db.Products.Add(product);
			db.SaveChanges();
			return product;
		}

		public Product Edit(Product product)
		{
			db.Entry(product).State = EntityState.Modified;
			db.SaveChanges();
			return product;
		}

		public void Remove(Product product)
		{
			db.Products.Remove(product);
			db.SaveChanges();
		}

		public void RemoveAll()
		{
			db.Products.RemoveRange(db.Products.ToList());
			db.SaveChanges();
		}
	}
}