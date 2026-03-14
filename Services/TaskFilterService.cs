namespace Task_Tracker_API.Services;

using Task_Tracker_API.Domain;

public static class TaskFilterService
{
    public static IEnumerable<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<BugReportTask>()
            .Where(t => t is { IsCompleted: false, SeverityLevel: "High" })
            .OrderByDescending(t => t.CreatedAt);
    }

    public static int GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<FeatureRequestTask>()
            .Where(t => t is { IsCompleted: false })
            .Sum(t => t.EstimatedHours);
    }
}