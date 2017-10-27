using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarioProducts.Models
{
	public class MarioProductsDbContext : DbContext
	{
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Review> Reviews { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder
			.UseMySql(@"Server=localhost;Port=8889;database=mario_products;uid=root;pwd=root;");
	}

}