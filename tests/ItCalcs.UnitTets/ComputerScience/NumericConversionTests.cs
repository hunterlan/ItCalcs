using ItCalcs.Application.ComputerScience.Factories;
using ItCalcs.Application.ComputerScience.NumericConversion;

namespace ItCalcs.UnitTets.ComputerScience;

public class NumericConversionTests
{
    [Fact]
    public void Binary_To_Decimal_Conversion_Test()
    {
        var numericConversion = NumericConversionFactory.Create("bidec");

        List<string> expectedValues = ["34", "255", "1348"];
        List<string> actualValues =
        [
            numericConversion.Convert("100010"),
            numericConversion.Convert("11111111"),
            numericConversion.Convert("101 01000100")
        ];
        
        Assert.Equal(expectedValues, actualValues);
    }
}