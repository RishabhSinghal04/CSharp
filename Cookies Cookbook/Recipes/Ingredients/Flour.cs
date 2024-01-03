
namespace CookiesCookbook.Recipies.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions =>
    $"Sieve. {base.PreparationInstructions}";
}