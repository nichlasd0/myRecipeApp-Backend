using System.Collections.Generic;

namespace recipeapp_backend.Models.DTO
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

    }
}