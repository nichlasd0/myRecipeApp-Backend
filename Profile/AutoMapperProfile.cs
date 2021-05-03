using recipeapp_backend.Models;
using recipeapp_backend.Models.DTO;

namespace recipeapp_backend.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipes, RecipesDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Instruction, InstructionDto>();
        }
    }
}