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

    [Fact]
    public void Decimal_Validation_Test()
    {
        var hexdecConversion = NumericConversionFactory.Create("dechex");
        
        Assert.Throws<ArgumentException>(() => hexdecConversion.Convert("@hfskjag&nvbsjkacibn"));
    }

    [Fact]
    public void Hexadecimal_to_Decimal_Conversion_Test()
    {
        var conversion = NumericConversionFactory.Create("dechex");

        List<string> expectedValue = ["14971", "32572", "53257", "62745"];
        List<string> actualValues =
        [
            conversion.ReverseConvert("3A7B"),
            conversion.ReverseConvert("7F3C"),
            conversion.ReverseConvert("d009"),
            conversion.ReverseConvert("F519"),
        ];
        
        Assert.Equal(expectedValue, actualValues);
    }

    [Fact]
    public void Hexadecimal_Validation_Test()
    {
        var conversion = NumericConversionFactory.Create("dechex");
        
        Assert.Throws<ArgumentException>(() => conversion.Convert("3Z1AC"));
    }
}