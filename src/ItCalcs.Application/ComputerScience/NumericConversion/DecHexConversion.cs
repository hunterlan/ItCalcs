using System.Text;

namespace ItCalcs.Application.ComputerScience.NumericConversion;

public class DecHexConversion : INumericConversion
{
    public string Convert(string numericValue)
    {
        if (!long.TryParse(numericValue, out var value))
        {
            throw new ArgumentException("Invalid numeric value", nameof(numericValue));
        }

        StringBuilder hexSb = new();
        
        while (value > 0)
        {
            var reminder = value % 16;
            hexSb.Insert(0, GetLetter(reminder));
            value /= 16;
        }

        return hexSb.ToString();
    }

    public string ReverseConvert(string hexValue)
    {
        hexValue = hexValue.ToUpperInvariant();
        long decimalValue = 0;
        
        for (var index = 0; index < hexValue.Length; index++)
        {
            var symbol = hexValue[index];
            
            if (long.TryParse(symbol.ToString(), out var numericValue))
            {
                decimalValue += numericValue * (long)Math.Pow(16, hexValue.Length - 1 - index);
            }
            else
            {
                var transformedNumericValue = GetNumber(symbol);
                if (transformedNumericValue is null)
                {
                    throw new ArgumentException("Invalid hexadecimal value", nameof(hexValue));
                }
                decimalValue += transformedNumericValue.Value * (long)Math.Pow(16, hexValue.Length - 1 - index);
            }
        }

        return decimalValue.ToString();
    }

    private string GetLetter(long reminder)
    {
        if (reminder is > 15 or < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(reminder));
        }

        return reminder switch
        {
            10 => "A",
            11 => "B",
            12 => "C",
            13 => "D",
            14 => "E",
            15 => "F",
            _ => reminder.ToString()
        };
    }

    private long? GetNumber(char letter)
    {
        return letter switch
        {
            'A' => 10,
            'B' => 11,
            'C' => 12,
            'D' => 13,
            'E' => 14,
            'F' => 15,
            _ => null
        };
    }
}