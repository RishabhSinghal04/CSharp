using CookiesCookbook.App;
using CookiesCookbook.DataAccess;
using CookiesCookbook.Recipes;
using CookiesCookbook.Recipes.Ingredients;

var ingredientRegister = new IngredientRegister();

const FileFormat fileFormat = FileFormat.json;

IStringsRepository stringsRepository = fileFormat == FileFormat.json
    ? new StringsJsonRepository()
    : new StringsTextualRepository();

string fileExtension = fileFormat == FileFormat.json ? "json" : "txt";

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientRegister),
    new RecipesConsoleUserInteraction(
        ingredientRegister));

cookiesRecipesApp.Run("recipes." + fileExtension);

public enum FileFormat
{
    json,
    txt
}
