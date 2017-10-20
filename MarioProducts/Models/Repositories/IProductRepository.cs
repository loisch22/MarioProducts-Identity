using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioProducts.Models.Repositories
{
	public interface IProductRepository
	{
		IQueryable<Review> Reviews { get; }
		IQueryable<Product> Products { get; }
		Product Save(Product product);
		Product Edit(Product product);
		void Remove(Product product);
	}
}