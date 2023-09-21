using NSubstitute;
namespace StringCalculator;

public class StringCalculatorTests
{
    private readonly StringCalculator calculator;

    public StringCalculatorTests()
    {
        calculator = new StringCalculator(Substitute.For<ILogger>(), Substitute.For<IWebService>());
    }
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Fact]
    public void ArbitraryNumbers()
    {
        var result = calculator.Add("1,2,3,4,5,6,7,8,9");

        Assert.Equal(45, result);
    }
}
