namespace TodosApi.Controllers;

[ApiController]
public class TodoListController : ControllerBase
{

    private readonly IManageTodoLists _todoListManager;

    public TodoListController(IManageTodoLists todoListManager)
    {
        _todoListManager = todoListManager;
    }

    // GET /todo-list

    [HttpPost("/todo-list")]
    public async Task<ActionResult> AddTodoItem([FromBody] TodoCreateRequest request)
    {


        TodoItemResponse response = await _todoListManager.AddTodoItemAsync(request);
        return StatusCode(201, response);
    }

    [HttpGet("/todo-list")]
    public async Task<ActionResult> GetTodoListAsync()
    {
        TodoListSummaryResponse response = await _todoListManager.GetAllTodosAsync();
        return Ok(response);
    }

    [HttpPost("/todo-list/completed-items")]
    public async Task<ActionResult> MarkItemCompleted([FromBody] TodoItemResponse request)
    {
        if (request.Description == "String Calculator")
        {
            await Task.Delay(2000);
            return BadRequest("This needs to stay on your list forever");
        }
        await _todoListManager.MarkItemCompletedAsync(request);
        return NoContent();
    }
}
