namespace ProductService.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ProductService.Database;
    using ProductService.Database.Entities;
    using System;
    using System.Collections.Generic;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return unitOfWork.Categories.Get();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return unitOfWork.Categories.GetByID(id);
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] Category model)
        {
            try
            {
                unitOfWork.Categories.Insert(model);
                unitOfWork.Commit();

                return StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT: api/Categories/5
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
