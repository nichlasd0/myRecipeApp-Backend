using System.Collections.Generic;

namespace recipeapp_backend.Models.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        
        public List<InstructionDto> Instructions { get; set; }
        public List<IngredientDto> Ingredients { get; set; } 
    }
}    