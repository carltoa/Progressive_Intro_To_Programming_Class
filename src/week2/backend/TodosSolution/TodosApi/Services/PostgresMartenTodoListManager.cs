using Marten;

namespace TodosApi.Services;

public class PostgresMartenTodoListManager : IManageTodoLists
{

    private readonly IDocumentSession _session;

    public PostgresMartenTodoListManager(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<TodoItemResponse> AddTodoItemAsync(TodoCreateRequest request)
    {

        var itemToSave = new TodoItemResponse
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Completed = false
        };

        _session.Insert(itemToSave);
        await _session.SaveChangesAsync();
        return itemToSave;
    }

    public async Task<TodoListSummaryResponse> GetAllTodosAsync()
    {
        var items = await _session.Query<TodoItemResponse>().ToListAsync();

        return new TodoListSummaryResponse { Items = items };
    }

    public async Task MarkItemCompletedAsync(TodoItemResponse request)
    {
        request.Completed = true;
        _session.Store(request); // "Upsert"
        await _session.SaveChangesAsync();
    }
}
