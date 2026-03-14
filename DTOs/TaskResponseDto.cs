namespace Task_Tracker_API.DTOs;

public record TaskResponseDto(
	Guid Id,
	string Title,
	string TaskType,
	bool IsCompleted,
	DateTime CreatedAt
);