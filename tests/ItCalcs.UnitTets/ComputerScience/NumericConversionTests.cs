using ItCalcs.Application.ComputerScience.Factories;

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

    [Fact]
    public void Binary_To_Decimal_Conversion_Exception_Test()
    {
        Assert.Throws<ArgumentException>(() => NumericConversionFactory.Create("bidec").Convert("648292163784217gfbsabhjbfashjb"));
    }

    [Fact]
    public void Decimal_To_Binary_Conversion_Test()
    {
        var numericConversion = NumericConversionFactory.Create("bidec");

        List<string> expectedValues = ["100", "100001", "1000000001", "1110000011"];
        List<string> actualValues = [
            numericConversion.ReverseConvert("4"),
            numericConversion.ReverseConvert("33"),
            numericConversion.ReverseConvert("513"),
            numericConversion.ReverseConvert("899")
        ];
        
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void Decimal_To_Binary_Argument_Exception_Test()
    {
        Assert.Throws<ArgumentException>(() => NumericConversionFactory.Create("bidec").ReverseConvert("a123c"));
    }
}