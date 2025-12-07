using Todo.DTOs;

namespace Todo.Interface
{
  public interface ITodoService
  {
    Task<TodoDto> CreateTodo(CreateTodoDto todo);
    Task<List<TodoDto>> GetAllTodos();
    Task<TodoDto> GetTodoById(int id);
    Task<TodoDto> UpdateTodo(int id, TodoDto todo);
    Task<TodoDto> DeleteTodo(int id);
  }
}