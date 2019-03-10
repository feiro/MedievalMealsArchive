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

        [HttpGet]
        public IEnumerable<Dish> GetDishes()
        {
            return _repository.GetDishes();
        }
    }
}