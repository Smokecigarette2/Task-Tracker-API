using Microsoft.EntityFrameworkCore;
using Task_Tracker_API.Data;
using Task_Tracker_API.Domain;

namespace Task_Tracker_API.Repositories;

// Handles all database operations via EF Core connected to Supabase


public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BaseTask>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<BaseTask?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task AddAsync(BaseTask task)
    {
        await _context.Tasks.AddAsync(task);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}