namespace ItCalcs.Application.ComputerScience.NumericConversion;

/// <summary>
/// Interface for all future numeric conversion classes. <br/>
/// Those classes should have name: NumSystemNumSystemConversion
/// </summary>
public interface INumericConversion
{
    /// <summary>
    /// Converts value from first numeric system to second numeric system.
    /// </summary>
    /// <param name="numericValue">Value of first numeric system</param>
    /// <returns>Result of conversion to second numeric system</returns>
    string Convert(string numericValue);
    /// <summary>
    /// Converts value from second numeric system to first numeric system.
    /// </summary>
    /// <param name="hexValue">Value of second numeric system</param>
    /// <returns>Result of conversion to first numeric system</returns>
    string ReverseConvert(string hexValue);
}