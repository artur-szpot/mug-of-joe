using CoffeeMugWebApi.Models.DataTypes;
using CoffeeMugWebApi.Models.InputModels;
using CoffeeMugWebApi.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMugWebApi.Controllers
{
    /*
     * The main Web API controller for the project.
     * Contains all the methods for basic CRUD operations.
     */
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        /* 
         * Initializes the controller with a suitable repository.
         */
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        /*
         * Returns all the Products.
         */
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _repository.GetAll();
        }

        /*
         * Returns a single Product if it exists.
         */
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var found = await _repository.GetById(id);

            if (found == null)
            {
                return NotFound();
            }

            return found;
        }

        /* 
         * Updates a single Product based on its Id.
         * Requires providing a full set of information.
         */
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductUpdateInputModel>> Put(ProductUpdateInputModel model)
        {
            if (model.Id == Guid.Empty || !ModelState.IsValid)
            {
                return BadRequest();
            }

            bool result = await _repository.Update(model);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /* 
         * Creates a new Product.
         * Requires providing a full set of information except the Id, which will be generated automatically.
         */
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Post(ProductCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Guid guid = await _repository.Create(model);

            return CreatedAtAction(nameof(Get), new { id = guid }, guid);

        }

        /*
         * Deletes a single Product if it exists.
         */
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            Product removed = await _repository.Remove(id);

            if (removed == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}