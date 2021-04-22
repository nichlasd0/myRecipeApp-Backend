using System.Collections.Generic;
using System.Linq;
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

        public RecipesController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
            
        }


        [HttpGet]
        public IEnumerable<RecipesDto> GetRecipes()
        {
            var recipesFromDb = _applicationDbContext.Recipes
                .Include(i => i.Ingredientses)
                .Include(o => o.Orders).ToList();
            
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipes, RecipesDto>();
                cfg.CreateMap<Ingredients, IngredientsDto>();
                cfg.CreateMap<Order, OrderDto>();
            });
            var mapper = new Mapper(config);
            List<RecipesDto> dto = mapper.Map<List<Recipes>, List<RecipesDto>>(recipesFromDb);
            return dto;
        }


        [HttpPost]
        public IActionResult SeedDatabase()
        {
            var order1 = new Order
            {
                OrderStep = "test"
            };
            var ingredient1 = new Ingredients
            {
                Name = "Normalstora Lökar",
                Amount = "2",
                Unit = "hela",
            };

            var recipe1 = new Recipes
            {
                Name = "Picklad rödlök",
                Description =
                    "Sugen på något nytt till dina tacos eller hamburgare? Då är picklad rödlök perfekt. Det enda du behöver är ättika, rödlök och socker. Skiva löken i tunna ringar som du sen lägger i lagen och låter stå över natten. Det är riktigt vackert och smakligt. För lite extra sting kan du addera en gnutta chili i lagen.",
                ImagePath =
                    "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/imagevaultfiles/id_147878/cf_259/picklad_rodlok.jpg",
                Orders = new List < Order >{order1},
                Ingredientses = new List<Ingredients>{ingredient1}

            };

            _applicationDbContext.Recipes.Add(recipe1);
            _applicationDbContext.SaveChanges();

            return Ok();
        }
        // [HttpPut]
        // public IEnumerable<RecipesDto> SetRecipes()
        // {
        //     
        // }
    }
}