using Banking.Domain;

namespace Banking.UnitTests.BonusCalculation;
public class StandardBonusCalculatorTests
{
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    public void AccountsThatMeetTheCriteriaGetTheBonus(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }
    [Theory]
    [InlineData(4999.99, 100, 0)]
    public void AccountsThatDoNotMeetTheCriteriaGetNoBonus(decimal balance, decimal deposit, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBonusForAccountDeposit(balance, deposit);

        Assert.Equal(expectedBonus, bonus);
    }
}
