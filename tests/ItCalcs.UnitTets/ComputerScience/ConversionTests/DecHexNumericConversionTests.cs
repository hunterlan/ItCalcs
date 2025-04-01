using ItCalcs.Application.ComputerScience.Factories;

namespace ItCalcs.UnitTets.ComputerScience.ConversionTests;

public class DecHexNumericConversionTests
{
    [Fact]
    public void Decimal_To_Hexadecimal_Conversion_Test()
    {
        var hexdecConversion = NumericConversionFactory.Create("dechex");

        List<string> expectedValues = ["74", "A", "21", "9F1"];
        List<string> actualValues = [
            hexdecConversion.Convert("116"),
            hexdecConversion.Convert("10"),
            hexdecConversion.Convert("33"),
            hexdecConversion.Convert("2545"),
        ];
        
        Assert.Equal(expectedValues, actualValues);
    }
}