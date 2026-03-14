namespace Task_Tracker_API.Domain;
//   Abstract base class with required properties

public abstract class BaseTask
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsCompleted { get; private set; } = false;

    public delegate void TaskCompletedHandler(BaseTask task); //Delegate and event declaration
    public event TaskCompletedHandler? OnTaskCompleted;

    public void CompleteTask()
    {
        IsCompleted = true;
        OnTaskCompleted?.Invoke(this);
    }
}