namespace Task_Tracker_API.DTOs;

public class CreateBugReportDto
{
    public string Title { get; set; } = string.Empty;
    public string SeverityLevel { get; set; } = string.Empty;
}