using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.UnitOfWork;

namespace ToDoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public TasksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;   
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery]int pageId,[FromQuery] int pageSize)
    {
        if (pageId <= 0)
        {
            return BadRequest("تعداد صفحه باید بزرگ تر از صفر0 باشد");
        }
                
        var count = Convert.ToDecimal(await _unitOfWork.Tasks.GetTotalCountAsync());
        var maxPageId = Math.Ceiling(count / pageSize);

        if (pageId > maxPageId)
        {
            return BadRequest($"تعداد صفحه نمیتواند از {maxPageId} بزرگ تر باشد");
        }

        var tasks = await _unitOfWork.Tasks.GetAllAsync(pageId, pageSize);
           
        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> FindAsync([FromRoute]Guid id)
    {
        var task = await _unitOfWork.Tasks.FindByIdAsync(id, false);

        if (task is null)
        {
            return NotFound("task مورد نظر پیدا نشد");
        }
            
        return Ok(task);
    }

    [HttpPost] 
    public async Task<IActionResult> AddAsync([FromBody]TaskModel task)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        task.Id = Guid.NewGuid();
        List<Task> tasksList = [_unitOfWork.Tasks.AddAsync(task), _unitOfWork.SaveChangesAsync()];

        await Task.WhenAll(tasksList);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] TaskModel task,[FromRoute] Guid id)
    {
        var currentTask = await _unitOfWork.Tasks.FindByIdAsync(id , true);

        if (currentTask is null)
        {
            return NotFound("task مورد نظر پیدا نشد");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        task.Id = id;
        _unitOfWork.Tasks.Update(task);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var task = await _unitOfWork.Tasks.FindByIdAsync(id, true);

        if (task is null)
        {
            return NotFound("task مورد نظر پیدا نشد");  
        }

        _unitOfWork.Tasks.Delete(task);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}