using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MedievalFoodAndDrinkArchiveApp.Models
{
    public class MedievalMealsArchiveContext : DbContext
    {
        public MedievalMealsArchiveContext(DbContextOptions<MedievalMealsArchiveContext> options):base(options)
        {
            
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
