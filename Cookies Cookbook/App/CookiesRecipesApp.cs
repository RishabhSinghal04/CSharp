using CookiesCookbook.Recipes;
using CookiesCookbook.Recipies;

namespace CookiesCookbook.App;

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRepository recipesRepository,
    IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(in string filePath)
    {
        // Read all recipies
        var allRecipes = _recipesRepository.Read(filePath);

        // Display all recipies
        _recipesUserInteraction.DisplayExistingRecipes(allRecipes);

        // Prompt user to create a new cookie recipe
        _recipesUserInteraction.PromptToCreateRecipe();

        // Read ingredients from user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Any())
        {
            // Create a new recipe
            var recipe = new Recipe(ingredients);

            // Add recipe
            allRecipes.Add(recipe);

            // Write all recipes in file
            _recipesRepository.Write(filePath, allRecipes);

            _recipesUserInteraction.ShowMessage("Recipe Added");
            _recipesUserInteraction.ShowMessage(recipe.ToString());

        }
        else
        {
            _recipesUserInteraction.ShowMessage("No Ingredient Selected" +
            "\nRecipe will not be saved");
        }
        _recipesUserInteraction.Exit();
    }
}