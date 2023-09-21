namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _opsApi;
    public StringCalculator(ILogger logger, IWebService opsApi)
    {
        _logger = logger;
        _opsApi = opsApi;

    }
    public int Add(string numbers)
    {
        int result;
        if (numbers == "")
        {
            result = 0;
        }
        else
        {
            result = numbers.Split(',').Select(int.Parse).Sum();
        }
        try
        {
            _logger.Write(result.ToString());
        }
        catch (LoggerException)
        {
            //ping the QA Web server
            _opsApi.NotifyOfLoggerFailure("Logger Went Boom");

        }
        return result;
    }
}

public interface ILogger
{
    void Write(string message);
}

public interface IWebService
{
    void NotifyOfLoggerFailure(string message);
}

public class LoggerException : ApplicationException { }
