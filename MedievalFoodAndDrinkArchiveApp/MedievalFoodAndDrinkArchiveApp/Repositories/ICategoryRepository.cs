using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;

namespace MedievalFoodAndDrinkArchiveApp.Repositories
{
    public interface ICategoryRepository
    {
        // Return a complete list of all available categories.
        IEnumerable<Category> GetCategories();
        // Return a specific category.
        Category GetCategoryById(int id);
        // Create/add a new category.
        Category CreateCategory(Category category);
        // Update information on existing category.
        Category UpdateCategory(Category category);
        // Delete specific category.
        void DeleteCategory(int id);
    }
}
