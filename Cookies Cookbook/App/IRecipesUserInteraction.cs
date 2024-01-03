using CookiesCookbook.Recipies;
using CookiesCookbook.Recipies.Ingredients;

namespace CookiesCookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(in string message);

    void Exit();
    void DisplayExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}