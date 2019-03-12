using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using MedievalFoodAndDrinkArchiveApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedievalFoodAndDrinkArchiveApp.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;

        // Use dependency injection in order to initialize var _repository. Use constructor. Add connection between interface and implementation in Startup.cs - ConfigureServices().
        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        /**
         * Get a complete list of categories.
         * Path: /api/categories
         */
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repository.GetCategories();
        }

        /**
         * Get a specific category by Id.
         * Path (e.g.): /api/categories/1
         */
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _repository.GetCategoryById(id);

            // Check for status code 404 = not found
            if (category == null)
            {
                return NotFound();
            }
            // Return HTTP Status code 200 and category data values, if data for id exists.
            return Ok(category);
        }

        /*
         * Create a new category in repository.
         */
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _repository.CreateCategory(category);
            return CreatedAtAction("Get", new { id = category.Id }, result);
        }

        /**
         * Update a category in repository.
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_repository.GetCategoryById(id) == null)
            {
                return NotFound();
            }

            var result = _repository.UpdateCategory(category);
            return Ok(result);
        }

        /**
         * Delete a specific category in repository.
         */
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.GetCategoryById(id) == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(id);
            return NoContent();
        }
    }
}
