namespace BusinessClockApi.Models;

public record ClockResponse(bool open, DateTime? opensNext);

