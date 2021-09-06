using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductReviewDetailsViewModel
    {
        public ProductReviewDetailsViewModel(int id, string author, string rating, string comments, DateTime registeredAt)
        {
            Id = id;
            Author = author;
            Rating = rating;
            Comments = comments;
            RegisteredAt = registeredAt;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Rating { get; set; }
        public string Comments { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}
