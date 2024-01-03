
namespace CookiesCookbook.Recipies.Ingredients;

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions =>
    $"Take a half teaspoon {base.PreparationInstructions}";
}