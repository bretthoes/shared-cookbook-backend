using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Data;
using SharedCookbookBackend.Models;
using SharedCookbookBackend.Services;

namespace SharedCookbookBackend.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // GET: api/Recipes/ByPersonId/{personId}
        [HttpGet("person/{personId}/recipes")]
        public async Task<ActionResult<List<Recipe>>> GetRecipesInCookbook(int cookbookId)
        {
            var recipes = await _recipeService.GetRecipesInCookbook(cookbookId);

            if (recipes == null || !recipes.Any())
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            bool updated = await _recipeService.UpdateRecipe(id, recipe);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _recipeService.CreateRecipe(recipe);
            return CreatedAtAction("GetRecipe", new { id = recipe.RecipeId }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipe(id);
            return NoContent();
        }
    }
}
