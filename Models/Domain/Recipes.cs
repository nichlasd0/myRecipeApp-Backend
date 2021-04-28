using System.Collections.Generic;

namespace recipeapp_backend.Models
{
    public class Recipes
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Ingredients> Ingredients { get; set; } 

    }
}