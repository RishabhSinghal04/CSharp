using CookiesCookbook.Recipies.Ingredients;

namespace CookiesCookbook.Recipes.Ingredients;

public interface IIngredientRegister
{
    IEnumerable<Ingredient> All { get; }
    Ingredient? GetByID(int id);
}