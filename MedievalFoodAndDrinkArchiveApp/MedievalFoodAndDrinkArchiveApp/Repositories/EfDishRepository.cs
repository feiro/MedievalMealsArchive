using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedievalFoodAndDrinkArchiveApp.Repositories
{
    public class EfDishRepository : IDishRepository
    {
        // EF context
        private readonly MedievalMealsArchiveContext _db;
        // Handle through dependency injection
        public EfDishRepository(MedievalMealsArchiveContext db)
        {
            _db = db;
        }
         
        public IEnumerable<Dish> GetDishes()
        {
            // return _db.Dishes;

            // Even include load of category when getting dishes.
            return _db.Dishes.Include(x => x.Category);
        }

        public Dish GetDishById(int id)
        {
            // Category information will not be loaded.
            // return _db.Dishes.Find(id);

            // Even include load of category information when getting dish.
            return _db.Dishes.Include(x => x.Category).SingleOrDefault(x => x.Id == id);
        }

        public Dish CreateDish(Dish dish)
        {
            _db.Dishes.Add(dish);
            _db.SaveChanges();
            return dish;
        }

        public Dish UpdateDish(Dish dish)
        {
            var dishForUpdate = _db.Dishes.Find(dish.Id);
            dishForUpdate.Name = dish.Name;
            dishForUpdate.Description = dish.Description;
            dishForUpdate.Price = dish.Price;
            dishForUpdate.CategoryId = dish.CategoryId;
            _db.SaveChanges();
            return dishForUpdate;
        }

        public void DeleteDish(int id)
        {
            var dish = _db.Dishes.Find(id);
            if (dish != null)
            {
                _db.Dishes.Remove(dish);
                _db.SaveChanges();
            }
        }
    }
}
