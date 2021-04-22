using System.Collections.Generic;

namespace recipeapp_backend.Models.DTO
{
    public class IngredientsDto
    {
        public int IngredientId { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

    }
}