using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MarioProducts.Models;

namespace MarioProducts.Models
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string CountryOfOrigin { get; set; }
        public DateTime CreateDate {get; set;}
        public virtual ICollection<Review> Reviews { get; set; }

		public override bool Equals(System.Object otherProduct)
		{
			if (!(otherProduct is Product))
			{
				return false;
			}
			else
			{
				Product newProduct = (Product)otherProduct;
				return this.ProductId.Equals(newProduct.ProductId);
			}
		}

		public override int GetHashCode()
		{
			return this.ProductId.GetHashCode();
		}

        public Product(string name, int cost, string countryOfOrigin, int productId)
        {
            this.Name = name;
            this.Cost = cost;
            this.CountryOfOrigin = countryOfOrigin;
            this.CreateDate = DateTime.Now;
            this.ProductId = productId;
        }

    }
}
