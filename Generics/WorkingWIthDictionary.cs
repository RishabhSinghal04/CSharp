
class WorkingWIthDictionary
{
    private static Dictionary<string, string> _countryToCurrencyMapping = new();
    public static void DictionaryWork()
    {
        _countryToCurrencyMapping.Add("USA", "USD");
        _countryToCurrencyMapping.Add("India", "INR");
        _countryToCurrencyMapping.Add("Spain", "EUR");
        _countryToCurrencyMapping.Add("Italy", "EUR");

        _countryToCurrencyMapping["Poland"] = "PLN";

        if (_countryToCurrencyMapping.ContainsKey("England"))
        {
            Console.WriteLine("Key Exists");
        }

        Console.WriteLine("Country \t Currency");
        Display();
    }

    public static void Display()
    {
        foreach (var countryCurrencyPair in _countryToCurrencyMapping)
        {
            Console.WriteLine($"{countryCurrencyPair.Key} \t\t {countryCurrencyPair.Value}");
        }
    }
}