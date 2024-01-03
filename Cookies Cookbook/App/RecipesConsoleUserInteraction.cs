using CookiesCookbook.Recipes.Ingredients;
using CookiesCookbook.Recipies;
using CookiesCookbook.Recipies.Ingredients;

namespace CookiesCookbook.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IIngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void ShowMessage(in string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("\nPress any key to exit....");
        Console.ReadKey();
    }

    public void DisplayExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Any())
        {
            int counter = 0;
            Console.WriteLine("Existing Recipes are:-\n");

            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"***** {++counter} *****\n{recipe}\n");
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe!\nAvailable ingredients are:-\n");
        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        var ingredients = new List<Ingredient>();

        do
        {
            Console.WriteLine("Add an ingredient by it's ID, or type anything else to finish.");
            string? userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int id))
            {
                break;
            }
            var selectedIngredient = _ingredientRegister.GetByID(id);
            if (selectedIngredient is not null)
            {
                ingredients.Add(selectedIngredient);
            }
        }
        while (true);

        return ingredients;
    }
}