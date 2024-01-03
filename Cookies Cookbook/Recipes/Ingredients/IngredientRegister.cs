using CookiesCookbook.Recipies.Ingredients;

namespace CookiesCookbook.Recipes.Ingredients;

public class IngredientRegister : IIngredientRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
{
    new WheatFlour(),
    new CoconutFlour(),
    new Butter(),
    new Chocolate(),
    new Sugar(),
    new Cardamom(),
    new Cinnamon(),
    new CocoaPowder(),
};

    public Ingredient? GetByID(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.ID == id)
            {
                return ingredient;
            }
        }
        return null;
    }
}