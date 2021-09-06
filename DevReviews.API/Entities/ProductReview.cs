using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        public ProductReview(string author, int rating, string comments, int productId)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            ProductId = productId;

            RegisteredAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime RegisteredAt { get; set; }
        public int ProductId { get; set; }
        
    }
}