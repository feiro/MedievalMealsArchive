using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalFoodAndDrinkArchiveApp.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        public double Price { get; set; }
        // Category choice: e.g. appetizers, main dishes, beverages
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    
    
}
