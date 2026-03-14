using Task_Tracker_API.Domain;

namespace Task_Tracker_API.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<BaseTask>> GetAllAsync();
    Task<BaseTask?> GetByIdAsync(Guid id);
    Task AddAsync(BaseTask task);
    Task SaveChangesAsync();
}