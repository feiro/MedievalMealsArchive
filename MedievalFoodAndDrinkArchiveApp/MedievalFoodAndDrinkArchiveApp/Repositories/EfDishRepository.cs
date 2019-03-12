using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;

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
            return _db.Dishes;
        }

        public Dish GetDishById(int id)
        {
            return _db.Dishes.Find(id);
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
