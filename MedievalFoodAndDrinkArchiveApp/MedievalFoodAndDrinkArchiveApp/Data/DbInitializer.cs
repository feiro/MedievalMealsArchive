using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MedievalFoodAndDrinkArchiveApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(MedievalMealsArchiveContext db, IHostingEnvironment env)
        {
            // Does database exist? If not, create db.
            db.Database.EnsureCreated();
            // Break if categories OR dishes already exist in db.
            if (db.Categories.Any() || db.Dishes.Any())
            {
                return;
            }

            var path = Path.Combine(env.ContentRootPath, "Data");
            var categoriesJson = File.ReadAllText(Path.Combine(path, "categories.json")); ;
            var dishesJson = File.ReadAllText(Path.Combine(path, "dishes.json"));

            // Deserialize content that has been read.
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson); ;
            var dishes = JsonConvert.DeserializeObject<List<Dish>>(dishesJson);

            foreach (var category in categories)
            {
                // Every dish where true that dish.CategoryId == category.Id.
                foreach (var dish in dishes.Where(x => x.CategoryId == category.Id))
                {
                    // Reset id value to work with EF. EF must be allowed to assign values for field Id.
                    dish.Id = 0;
                    // Add each meal (dish) to list of dishes per category.
                    category.Dishes.Add(dish);
                }
                // Reset id value to work with EF. EF must be allowed to assign values for field Id.
                category.Id = 0;
                // Add new category to DbSet for categories.
                db.Categories.Add(category);
            }

            db.SaveChanges();
        }
    }
}
