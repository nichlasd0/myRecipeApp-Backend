using AutoMapper.EquivalencyExpression;
using recipeapp_backend.Models;
using recipeapp_backend.Models.DTO;

namespace recipeapp_backend.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
             CreateMap<Recipe, RecipeDto>().ReverseMap()
                 .EqualityComparison((dtoP, rId) => dtoP.Id == rId.Id);
             
             CreateMap<Ingredient, IngredientDto>().ReverseMap()
                .EqualityComparison((dtoI, iId) => dtoI.Id == iId.Id);
             
            CreateMap<Instruction, InstructionDto>().ReverseMap()
                .EqualityComparison((dtoI, iId) => dtoI.Id == iId.Id);;
        }
    }
}