using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string title, string description, 
            decimal price, DateTime registeredAt, List<ProductReviewViewModel> reviews)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegisteredAt = registeredAt;
            Reviews = reviews;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisteredAt { get; set; }
            
        public List<ProductReviewViewModel> Reviews { get; set; }
       
    }

    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string author, int rating, string comments, DateTime registeredAt)
        {
            Id = id;
            Author = author;
            Rating = rating;
            Comments = comments;
            RegisteredAt = registeredAt;
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime RegisteredAt { get; private set; }
    }
}
