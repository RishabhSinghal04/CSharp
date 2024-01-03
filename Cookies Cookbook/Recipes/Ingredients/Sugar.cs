
namespace CookiesCookbook.Recipies.Ingredients;

public class Sugar : Ingredient
{
    public override int ID => 5;

    public override string Name => "Sugar";

    public override string PreparationInstructions =>
    $"{base.PreparationInstructions}";
}
