using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedievalFoodAndDrinkArchiveApp.Models
{
    public class Category
    {
        public Category()
        {
            Dishes = new HashSet<Dish>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}