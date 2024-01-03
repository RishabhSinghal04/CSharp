using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes.Ingredients;
using CookiesCookbook.Recipies;
using CookiesCookbook.Recipies.Ingredients;

namespace CookiesCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientRegister _ingredientRegister;
    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository,
    IIngredientRegister ingredientRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientRegister = ingredientRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }
        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIDs = recipeFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var textualID in textualIDs)
        {
            var id = int.Parse(textualID);
            var ingredient = _ingredientRegister.GetByID(id);
            if (ingredient is not null)
            {
                ingredients.Add(ingredient);
            }
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIDs = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIDs.Add(ingredient.ID);
            }
            recipesAsStrings.Add(string.Join(Separator, allIDs));
        }

        _stringsRepository.Write(filePath, recipesAsStrings);

    }
}