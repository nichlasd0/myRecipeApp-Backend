using System.Collections.Generic;

namespace recipeapp_backend.Models.DTO
{
    public class RecipesDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        
        public List<OrderDto> Orders { get; set; }
        public List<IngredientsDto> Ingredients { get; set; } 
    }
}    