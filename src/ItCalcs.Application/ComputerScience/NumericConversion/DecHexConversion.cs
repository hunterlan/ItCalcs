using System.Text;

namespace ItCalcs.Application.ComputerScience.NumericConversion;

public class DecHexConversion : INumericConversion
{
    public string Convert(string numericValue)
    {
        long value = 0;
        if (!long.TryParse(numericValue, out value))
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

    public string ReverseConvert(string numericValue)
    {
        return "";
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

    private long GetNumber(string letter)
    {
        return letter switch
        {
            "A" => 10,
            "B" => 11,
            "C" => 12,
            "D" => 13,
            "E" => 14,
            "F" => 15,
            _ => throw new ArgumentOutOfRangeException(nameof(letter))
        };
    }
}