namespace Task_Tracker_API.DTOs;

public class TaskResponseDto
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string TaskType { get; set; } = string.Empty;
	public bool IsCompleted { get; set; }
	public DateTime CreatedAt { get; set; }
}