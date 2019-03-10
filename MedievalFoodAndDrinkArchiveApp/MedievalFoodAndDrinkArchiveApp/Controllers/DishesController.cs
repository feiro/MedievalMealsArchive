using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedievalFoodAndDrinkArchiveApp.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IEnumerable<Dish> GetDishes()
        {
            return new[]
            {
                new Dish
                {
                    Name = "Truffle salad with garlic",
                    Description = "Aphrodisiacs",
                    Id = 1,
                    Price = 13.99
                }
            };
        }
    }
}