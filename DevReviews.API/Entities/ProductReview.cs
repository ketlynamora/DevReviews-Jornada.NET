using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        public ProductReview(string author, string rating, string comments, string productId)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            ProductId = productId;

            RegisteredAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Rating { get; set; }
        public string Comments { get; set; }
        public string ProductId { get; set; }
        public DateTime RegisteredAt { get; set; }
        
    }
}