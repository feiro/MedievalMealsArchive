using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MedievalFoodAndDrinkArchiveApp.Repositories
{
    public class FileDishRepository : IDishRepository
    {
        private readonly string _path;

        // Get object of type IHostingEnvironment through dependency injection. 
        public FileDishRepository(IHostingEnvironment env)
        {
            _path = Path.Combine(env.ContentRootPath, "Data", "dishes.json");
        }
        public IEnumerable<Dish> GetDishes()
        {
            var json = File.ReadAllText(_path);
            // Deserialize incoming values.
            return JsonConvert.DeserializeObject<IEnumerable<Dish>>(json);
        }

        public Dish GetDishById(int id)
        {
            throw new NotImplementedException();
        }

        public Dish CreateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public Dish UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public void DeleteDish(int id)
        {
            throw new NotImplementedException();
        }
    }
}
