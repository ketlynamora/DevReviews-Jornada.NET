using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreviews")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductReviewController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productReview = await _productRepository.GetReviewByIdAsync(id);

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productReview);

            if (productReview == null)
                return NotFound();

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _productRepository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { id = productReview.Id, productId = productId }, model );
        }
    }
}