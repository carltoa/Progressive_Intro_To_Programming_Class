using BusinessClockApi.Services;

namespace BusinessClockApi.UnitTests;
public class StandardBusinessClockTests
{
    [Theory]
    [InlineData("9/22/2023 8:59:00 AM", "9/22/2023 9:00:00 AM")] //friday before open
    [InlineData("9/21/2023 5:00:00 PM", "9/22/2023 9:00:00 AM")] //thursday after close
    [InlineData("9/22/2023 5:00:00 PM", "9/25/2023 9:00:00 AM")] //friday after close
    [InlineData("9/23/2023 10:00:00 AM", "9/25/2023 9:00:00 AM")] //saturday during open hours (should be closed all day saturday)
    [InlineData("9/24/2023 10:00:00 AM", "9/25/2023 9:00:00 AM")] //sunday during "open hours" (should be closed all day Sunday)
    public void Closed(string currentTime, string openNext)
    {
        var fakeSystemtime = Substitute.For<ISystemTime>();
        fakeSystemtime.GetCurrent().Returns(DateTime.Parse(currentTime));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemtime);

        var response = clock.GetClock();

        Assert.False(response.open);
        Assert.NotNull(response.opensNext);

        Assert.Equal(DateTime.Parse(openNext), response.opensNext.Value);
    }

    [Theory]
    [InlineData("9/22/2023 9:00:00 AM")]
    [InlineData("9/22/2023 4:59:59 PM")]
    public void Open(string currentTime)
    {
        var fakeSystemtime = Substitute.For<ISystemTime>();
        fakeSystemtime.GetCurrent().Returns(DateTime.Parse(currentTime));
        IProvideTheBusinessClock clock = new StandardBusinessClock(fakeSystemtime);

        var response = clock.GetClock();

        Assert.True(response.open);
        Assert.Null(response.opensNext);
    }
}
