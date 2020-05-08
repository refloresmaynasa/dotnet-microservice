namespace ProductService.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ProductService.Database;
    using ProductService.Database.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return unitOfWork.Products.Get().ToList();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = unitOfWork.Products.GetByID(id);
            return product;
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                unitOfWork.Products.Insert(model);
                unitOfWork.Commit();

                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
