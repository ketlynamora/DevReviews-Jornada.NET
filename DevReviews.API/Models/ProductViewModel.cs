using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
