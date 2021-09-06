using System;
using System.Collections.Generic;

namespace DevReviews.API.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;

            RegisteredAt = DateTime.Now;
            Reviews = new List<ProductReview>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisteredAt { get; set; }
        public List<ProductReview> Reviews { get; set; }
        
        public void addReview(ProductReview review)
        {
            Reviews.Add(review);
        }

        public void Update(string description, decimal price)
        {
            Description = description;
            Price = price;
        }
    }
}