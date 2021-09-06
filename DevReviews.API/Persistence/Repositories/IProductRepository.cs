using DevReviews.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetDetailsByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);


        Task<ProductReview> GetReviewByIdAsync(int id);
        Task AddReviewAsync(ProductReview productReview);
    }
}
