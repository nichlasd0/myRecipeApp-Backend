using System.Collections.Generic;

namespace recipeapp_backend.Models
{
    public class Recipe
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public List<Instruction> Instructions { get; set; } = new List<Instruction>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    }
}