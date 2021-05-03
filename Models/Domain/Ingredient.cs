

namespace recipeapp_backend.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public Recipes Recipes { get; set; }
    }
}