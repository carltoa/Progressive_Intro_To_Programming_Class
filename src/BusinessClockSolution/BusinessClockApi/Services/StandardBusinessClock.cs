namespace BusinessClockApi.Services;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _theClock;

    private readonly DayOfWeek[] _weekdays = new DayOfWeek[] {
        DayOfWeek.Monday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday,
        DayOfWeek.Thursday,
        DayOfWeek.Friday
    };

    private readonly DayOfWeek[] _weekends = new DayOfWeek[]
    {
        DayOfWeek.Saturday,
        DayOfWeek.Sunday
    };


    public StandardBusinessClock(ISystemTime theClock)
    {
        _theClock = theClock;
    }

    public ClockResponse GetClock()
    {
        var now = _theClock.GetCurrent();
        var dayOfTheWeek = now.DayOfWeek;

        var hour = now.Hour;

        var openingTime = new TimeSpan(9, 0, 0);
        var closingTime = new TimeSpan(17, 0, 0);

        var isOpen = dayOfTheWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => hour >= openingTime.Hours && hour < closingTime.Hours
        };

        if (isOpen)
        {
            return new ClockResponse(true, null);
        }

        DateTime openingNext = now.Date;

        if (_weekdays.Contains(dayOfTheWeek) && now.TimeOfDay.CompareTo(openingTime) < 0)
        {
            //we'll be open later today -- give user opening time
            openingNext = openingNext.Add(openingTime);
        }
        else if (_weekdays.Contains(dayOfTheWeek) && dayOfTheWeek != DayOfWeek.Friday)
        {
            //it's after hours somewhere between Mon-Thurs -- give opening time on next day
            openingNext = openingNext.AddDays(1);
            openingNext = openingNext.Add(openingTime);
        }
        else
        {
            //it's either after closing on Friday, or its the weekend -- return next weekday's opening time
            openingNext = dayOfTheWeek switch
            {
                DayOfWeek.Friday => openingNext.AddDays(3),
                DayOfWeek.Saturday => openingNext.AddDays(2),
                DayOfWeek.Sunday => openingNext.AddDays(1),
                _ => throw new Exception("This should not be possible")
            };

            openingNext = openingNext.Add(openingTime);
        }

        return new ClockResponse(false, openingNext);
    }
}