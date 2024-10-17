using static Calculator;

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("2")]
    [InlineData("3")]
    public void SingleIntergerReturnValue(string value)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(int.Parse(value), result);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("b")]
    public void SingleNumberNAN(string value)
    {
        var calculator = new Calculator();
        Assert.Throws<FormatException>(() => calculator.Add(value));
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void TakeCommaSeparatedValue(string value, int expectedValue)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2,3", 6)]
    public void TakeCommaSeparatedValueAndNewlineValue(string value, int expectedValue)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData("//#\n1#2#3", 6)]
    [InlineData("//#\n1#2,3\n1", 7)]
    [InlineData("//a\n1a2,3\n1", 7)]
    public void TakeCustomDelimiter(string value, int expectedValue)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData("-13", "-13")]
    [InlineData("-33,-2,1,3", "-33, -2")]
    [InlineData("//#\n-1#2,-3\n-1", "-1, -3, -1")]
    public void NotAllowNegativeNumber(string value, string expectedValue)
    {
        var calculator = new Calculator();
        var exception = Assert.Throws<NegativeNumbersException>(() => calculator.Add(value));
        string expectedMessage = "Negative number found: " + expectedValue;
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData("2,3,9876", 5)]
    public void IgnoredNumbersBiggerThanThousand(string value, int expectedValue)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData("//[***]\n1***2", 3)]
    [InlineData("//[***, #, !]\n1***2#3\n1!2", 9)]
    [InlineData("//[asdf, #, !]\n1asdf2#3\n1!2asdf6", 15)]
    public void AcceptCustomeDelimitersOfAnyLength(string value, int expectedValue)
    {
        var calculator = new Calculator();
        var result = calculator.Add(value);
        Assert.Equal(expectedValue, result);
    }

}
