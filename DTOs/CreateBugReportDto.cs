namespace Task_Tracker_API.DTOs;
// Modern C# : Record instead of class for simple data transfer objects

public record CreateBugReportDto(string Title, string SeverityLevel);