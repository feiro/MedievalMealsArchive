using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalFoodAndDrinkArchiveApp.Models;

namespace MedievalFoodAndDrinkArchiveApp.Repositories
{
    public interface IDishRepository
    {
        // Return a complete list of all available dishes.
        IEnumerable<Dish> GetDishes();
        // Return a specific dish.
        Dish GetDishById(int id);
        // Create/add a new dish.
        Dish CreateDish(Dish dish);
        // Update information on existing dish.
        Dish UpdateDish(Dish dish);
        // Delete specific dish.
        void DeleteDish(int id);
    }
}
