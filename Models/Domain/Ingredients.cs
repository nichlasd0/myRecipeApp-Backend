using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace recipeapp_backend.Models
{
    public class Ingredients
    {
        [Key]
        public int IngredientId { get; set; }
        public string Amount { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public Recipes Recipes { get; set; }
    }
}