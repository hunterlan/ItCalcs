using System.Text.RegularExpressions;

namespace ItCalcs.Application.ComputerScience.NumericConversion;

public partial class BiDecConversion : INumericConversion
{
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

    public string ReverseConvert(string numericValue)
    {
        throw new NotImplementedException();
    }

    [GeneratedRegex(@"^[01\s]+$")]
    private static partial Regex MyRegex();
}