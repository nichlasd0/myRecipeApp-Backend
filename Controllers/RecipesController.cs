using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipeapp_backend.Data;
using recipeapp_backend.Models;
using recipeapp_backend.Models.DTO;

namespace recipeapp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public RecipesController(ApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<RecipesDto> GetRecipes()
        {
            var recipesFromDb = _applicationDbContext.Recipes
                .Include(i => i.Ingredients)
                .Include(o => o.Instructions).ToList();
            
            return _mapper.Map<List<RecipesDto>>(recipesFromDb);
        }

        [HttpGet("{id}")]
        public ActionResult<RecipesDto> GetRecipeById(int id)
        {
            
            var singleRecipe = _applicationDbContext.Recipes
                .Include(i => i.Ingredients)
                .Include(o => o.Instructions).FirstOrDefault(x => x.Id == id);

            if (singleRecipe is null)
            {
                return NotFound();
            }

            return _mapper.Map<RecipesDto>(singleRecipe);
        }


        // [HttpPost]
        // public IActionResult SeedDatabase()
        // {
        //     var order1 = new Instruction
        //     {
        //         InstructionStep = "test"
        //     };
        //     var ingredient1 = new Ingredient
        //     {
        //         Name = "Normalstora Lökar",
        //         Amount = "2",
        //         Unit = "hela",
        //     };
        //
        //     var recipe1 = new Recipes
        //     {
        //         Name = "Picklad rödlök",
        //         Description =
        //             "Sugen på något nytt till dina tacos eller hamburgare? Då är picklad rödlök perfekt. Det enda du behöver är ättika, rödlök och socker. Skiva löken i tunna ringar som du sen lägger i lagen och låter stå över natten. Det är riktigt vackert och smakligt. För lite extra sting kan du addera en gnutta chili i lagen.",
        //         ImagePath =
        //             "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_147878/cf_259/picklad_rodlok.jpg",
        //         Instructions = new List < Instruction >{order1},
        //         Ingredients = new List<Ingredient>{ingredient1}
        //
        //     };
        //
        //     _applicationDbContext.Recipes.Add(recipe1);
        //     _applicationDbContext.SaveChanges();
        //
        //     return Ok();
        // }
        

        [HttpPost]
        public async Task<ActionResult<RecipesDto>> CreateRecipes(Recipes recipes)
        {
            await _applicationDbContext.Recipes.AddAsync(recipes);
            await _applicationDbContext.SaveChangesAsync();
            
            return _mapper.Map<RecipesDto>(recipes);
        }
    }
}