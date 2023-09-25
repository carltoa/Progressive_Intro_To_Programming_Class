namespace BusinessClockApi.Services;

public class SuperDeluxeBusinessClock : IProvideTheBusinessClock
{
    //private readonly ISystemTime _systemTime;
    //private readonly ILookupCrapInTheDatabase 

    public ClockResponse GetClock()
    {
        return new ClockResponse(false, null);
    }
}
