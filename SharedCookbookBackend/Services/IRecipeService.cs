using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesInCookbook(int cookbookId);
        Task<Recipe> GetRecipe(int id);
        Task<bool> UpdateRecipe(int id, Recipe Recipe);
        Task<Recipe> CreateRecipe(Recipe Recipe);
        Task DeleteRecipe(int id);
        bool RecipeExists(int id);
    }
}
