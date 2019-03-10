using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalFoodAndDrinkArchiveApp.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        // Category choice: e.g. appetizers, main dishes, beverages
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    
    
}
