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
            throw new NotImplementedException();
        }

        public Dish GetDishById(int id)
        {
            throw new NotImplementedException();
        }

        public Dish CreateDish(Dish dish)
        {
            _db.Dishes.Add(dish);
            _db.SaveChanges();
            return dish;
        }

        public Dish UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
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
