using System.Text;
using System.Text.RegularExpressions;

namespace ItCalcs.Application.ComputerScience.NumericConversion;

/// <inheritdoc/>
public partial class BiDecConversion : INumericConversion
{
    /// <exception cref="ArgumentException">Wrong binary numeric format</exception>
    /// <inheritdoc/>
    public string Convert(string numericValue)
    {
        var regex = MyRegex();
        if (!regex.IsMatch(numericValue))
        {
            throw new ArgumentException("Binary numeric value should contain only zeroes and ones!",
                nameof(numericValue));
        }
        
        var copyNumericValue = numericValue.Replace(" ", string.Empty);
        
        var bitCounter = (int)Math.Pow(2, copyNumericValue.Length - 1);
        var decimialValue = 0;
        
        foreach (var bit in copyNumericValue)
        {
            if (bit is '1')
            {
                decimialValue += bitCounter;
            }

            bitCounter /= 2;
        }

        return decimialValue.ToString();
    }

    /// <exception cref="ArgumentException">Wrong decimal numeric format</exception>
    /// <inheritdoc/>
    public string ReverseConvert(string numericValue)
    {
        long value = 0;
        if (!long.TryParse(numericValue, out value))
        {
            throw new ArgumentException("Decimal numeric value should contain only digits!", nameof(numericValue));
        }

        var highestBit = (long)Math.Log2(value);
        var multipliedBit = (long)Math.Pow(2, highestBit);
        
        var binaryValueSb = new StringBuilder();

        while (value > 0 || multipliedBit >= 1)
        {
            if (value - multipliedBit >= 0)
            {
                binaryValueSb.Append('1');
                value -= multipliedBit;
            }
            else
            {
                binaryValueSb.Append('0');
            }
            
            multipliedBit /= 2;
        }

        return binaryValueSb.ToString();
    }

    [GeneratedRegex(@"^[01\s]+$")]
    private static partial Regex MyRegex();
}