using ItCalcs.Application.ComputerScience.NumericConversion;

namespace ItCalcs.Application.ComputerScience.Factories;

/// <summary>
/// Factory pattern class
/// </summary>
public class NumericConversionFactory
{
    /// <summary>
    /// Factory pattern methord that return concrete instance of INumericConversion
    /// </summary>
    /// <param name="type">Name of concrete conversion</param>
    /// <returns>New concrete instance of numeric conversion</returns>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="ArgumentException">Wrong name</exception>
    public static INumericConversion Create(string type)
    {
        return type switch
        {
            "bidec" => new BiDecConversion(),
            "dechex" => new DecHexConversion(),
            "hexbi" => throw new NotImplementedException(),
            _ => throw new ArgumentException($"Wrong value", nameof(type))
        };
    }
}