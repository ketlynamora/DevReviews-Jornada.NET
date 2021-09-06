
using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static DevReviews.API.Models.ProductDetailsViewModel;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _autoMapper;
        

        public ProductsController(DevReviewsDbContext dbContext, IMapper autoMapper)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;

            var productViewModel = _autoMapper.Map<List<ProductViewModel>>(products);
            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            var productDetails = _autoMapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            _dbContext.Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model)
        {
            if (model.Description.Length > 50)
                return BadRequest();

            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Update(model.Description, model.Price);

            return NoContent();
        }
    }
}