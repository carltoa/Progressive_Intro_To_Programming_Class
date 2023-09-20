
namespace StringCalculator;

public class StringCalculatorTests
{
    string maxIntAsString = string.Concat("", int.MaxValue.ToString());

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("12", 12)]
    [InlineData("2147483647", int.MaxValue)]
    public void SingleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0,0", 0)]
    [InlineData("1,2", 3)]
    [InlineData("108,2", 110)]
    [InlineData("0,2147483647", 2147483647)]
    [InlineData("2147483647,0", 2147483647)]
    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0,0,0", 0)]
    [InlineData("1,2,3", 6)]
    [InlineData("50,50,50", 150)]
    [InlineData("1000, 2578, 98765", 1000 + 2578 + 98765)]
    [InlineData("2147483647,0,0", 2147483647)]
    public void ManyDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2,4\n82", 89)]
    [InlineData("1\n1\n1\n1\n1\n1", 6)]
    public void NewLineAndCommaDelimiters(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1,1", 3)]
    [InlineData("//;\n1;1;1;1", 4)]
    [InlineData("//;\n1,1,1", 3)]
    [InlineData("//;\n1\n1\n1", 3)]
    [InlineData("//;\n1,1;1\n1", 4)]
    [InlineData("//$\n1$1$1$1", 4)]
    [InlineData("//!\n1!1!1", 3)]
    public void UserSpecifiesAdditionalDelimiter(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
