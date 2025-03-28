using ItCalcs.Application.ComputerScience.NumericConversion;

namespace ItCalcs.Application.ComputerScience.Factories;

public class NumericConversionFactory
{
    public static INumericConversion Create(string type)
    {
        return type switch
        {
            "bidec" => new BiDecConversion(),
            "dechex" => throw new NotImplementedException(),
            "hexbi" => throw new NotImplementedException(),
            _ => throw new ArgumentException($"Wrong value", nameof(type))
        };
    }
}