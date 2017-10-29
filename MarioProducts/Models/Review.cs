using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MarioProducts.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 50, ErrorMessage = "Invalid")]
        public string ContentBody { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }

        public virtual ApplicationUser Admin { get; set; }

		public override bool Equals(System.Object otherReview)
		{
			if (!(otherReview is Review))
			{
				return false;
			}
			else
			{
				Review newReview = (Review)otherReview;
				return this.ReviewId.Equals(newReview.ReviewId);
			}
		}

		public override int GetHashCode()
		{
			return this.ReviewId.GetHashCode();
		}

        public Review(string author, string contentBody, int rating, int productId)
        {
          
            this.Author = author;
            this.ContentBody = contentBody;
            this.Rating = rating;
            this.ProductId = productId;
        }

        public Review()
        {
        }

    }
}
