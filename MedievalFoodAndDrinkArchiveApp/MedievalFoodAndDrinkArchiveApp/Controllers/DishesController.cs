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
    public class DishesController : Controller
    {
        private readonly IDishRepository _repository;

        // Use dependency injection in order to initialize var _repository. Use constructor. Add connection between interface and implementation in Startup.cs - ConfigureServices().
        public DishesController(IDishRepository repository)
        {
            _repository = repository;
        }

        /**
         * Get a complete list of dishes.
         * Path: /api/dishes
         */
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return _repository.GetDishes();
        }

        /**
         * Get a specific dish by Id.
         * Path (e.g.): /api/dishes/1
         */
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dish = _repository.GetDishById(id);

            // Check for status code 404 = not found
            if (dish == null)
            {
                return NotFound();
            }
            // Return HTTP Status code 200 and dish data values, if data for id exists.
            return Ok(dish);
        }

    }
}