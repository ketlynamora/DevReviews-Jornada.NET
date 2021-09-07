using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _autoMapper;
        

        public ProductsController(IProductRepository productRepository, IMapper autoMapper)
        {
            _productRepository = productRepository;
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            var productViewModel = _autoMapper.Map<List<ProductViewModel>>(products);
            return Ok(productViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetDetailsByIdAsync(id);

            if (product == null)
                return NotFound();

            var productDetails = _autoMapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }

        /// <summary>
        /// Cadastro de Produto
        /// </summary>
        /// <remarks>Requisição:
        /// {
        ///     "title": "Um chinelo top",
        ///     "description": "Um chinelo de marca",
        ///     "price": 100
        /// }
        /// </remarks>
        /// <param name="model">Objeto com dados de cadastro de Producto</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            Log.Information("Método POST chamado!");

            await _productRepository.AddAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductInputModel model)
        {
            
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            product.Update(model.Description, model.Price);

            await _productRepository.UpdateAsync(product);

            return NoContent();
        }
    }
}