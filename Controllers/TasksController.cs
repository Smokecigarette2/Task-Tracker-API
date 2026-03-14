using Microsoft.AspNetCore.Mvc;
using Task_Tracker_API.Domain;
using Task_Tracker_API.DTOs;
using Task_Tracker_API.Repositories;

//  REST API controller with three required endpoints

namespace Task_Tracker_API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet] //Endpoint 1: GET /api/tasks - retrieve all tasks
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _repository.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost("bug")] //Endpoint 2: POST /api/tasks/bug - create a new bug report
    public async Task<IActionResult> CreateBug([FromBody] CreateBugReportDto dto)
    {
        var task = new BugReportTask
        {
            Title = dto.Title,
            SeverityLevel = dto.SeverityLevel
        };

        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();

        return Ok(task);
    }

    [HttpPut("{id}/complete")] //Endpoint 3: PUT /api/tasks/{id}/complete - mark task as complete
    public async Task<IActionResult> CompleteTask(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        task.CompleteTask();
        await _repository.SaveChangesAsync();

        return Ok(task);
    }
}