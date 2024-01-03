
namespace CookiesCookbook.Recipies.Ingredients;

public class CocoaPowder : Ingredient
{
    public override int ID => 8;

    public override string Name => "Cocoa powder";

    public override string PreparationInstructions =>
    $"{base.PreparationInstructions}";
}