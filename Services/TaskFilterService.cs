namespace Task_Tracker_API.Services;

using Task_Tracker_API.Domain;

public static class TaskFilterService
{
    public static IEnumerable<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<BugReportTask>()
            .Where(t => !t.IsCompleted && t.SeverityLevel == "High")
            .OrderByDescending(t => t.CreatedAt);
    }

    public static int GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<FeatureRequestTask>()
            .Where(t => !t.IsCompleted)
            .Sum(t => t.EstimatedHours);
    }
}