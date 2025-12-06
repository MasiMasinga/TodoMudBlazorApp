using Todo.DTOs;

namespace Todo.Interface
{
  public interface ITodoService
  {
    Task<List<TodoDto>> GetAllTodos();
    Task<TodoDto> GetTodoById(int id);
    Task<TodoDto> CreateTodo(TodoDto todo);
    Task<TodoDto> UpdateTodo(int id, TodoDto todo);
    Task<TodoDto> DeleteTodo(int id);
  }
}