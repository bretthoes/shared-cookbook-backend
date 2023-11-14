using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Data;
using SharedCookbookBackend.Enums;
using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly SharedCookbookContext _context;

        public RecipeService(SharedCookbookContext context)
        {
            _context = context;
        }

        #region Create

        public async Task<Recipe> CreateRecipe(Recipe Recipe)
        {
            _context.Recipes.Add(Recipe);
            await _context.SaveChangesAsync();
            return Recipe;
        }

        #endregion Create

        #region Read

        public async Task<List<Recipe>> GetRecipesInCookbook(int cookbookId)
        {
            var recipes = await _context.Recipes
                .Where(r => r.CookbookId == cookbookId)
                .OrderBy(r => r.Title)
                .ToListAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        #endregion Read

        #region Update

        public async Task<bool> UpdateRecipe(int id, Recipe Recipe)
        {
            if (id != Recipe.RecipeId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true; // Update was successful
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    throw new KeyNotFoundException("Recipe not found");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception)
            {
                return false; // Update failed
            }
        }

        #endregion Update

        #region Delete

        public async Task DeleteRecipe(int id)
        {
            var Recipe = await _context.Recipes.FindAsync(id);
            if (Recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found");
            }

            _context.Recipes.Remove(Recipe);
            await _context.SaveChangesAsync();
        }

        #endregion Delete

        #region Helper

        public bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }

        #endregion Helper
    }
}
