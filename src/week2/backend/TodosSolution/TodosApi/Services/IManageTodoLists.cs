namespace TodosApi.Services;

public interface IManageTodoLists
{
    Task<TodoItemResponse> AddTodoItemAsync(TodoCreateRequest request);
    Task<TodoListSummaryResponse> GetAllTodosAsync();
}
