using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedievalFoodAndDrinkArchiveApp.Repositories
{
    public class EfCategoryRepository : ICategoryRepository
    {
        // EF context
        private readonly MedievalMealsArchiveContext _db;
        // Handle through dependency injection
        public EfCategoryRepository(MedievalMealsArchiveContext db)
        {
            _db = db;
        }
        public IEnumerable<Category> GetCategories()
        {
            // Even include load of dishes when getting categories.
            return _db.Categories.Include(x => x.Dishes);
        }

        public Category GetCategoryById(int id)
        {
            // Dish information will not be loaded.
            // return _db.Categories.Find(id);

            // Even include load of dishes when getting categories.
            return _db.Categories.Include(x => x.Dishes).SingleOrDefault(x => x.Id == id);  
        }

        public Category CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var categoryForUpdate = _db.Categories.Find(category.Id);
            categoryForUpdate.Name = category.Name;
            categoryForUpdate.Description = category.Description;
            _db.SaveChanges();
            return categoryForUpdate;
        }

        public void DeleteCategory(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
        }
    }
}
