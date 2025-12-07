using Todo.Interface;
using Todo.DTOs;
using Todo.Data;
using Microsoft.EntityFrameworkCore;

namespace Todo.Services
{
  public class TodoService : ITodoService
  {
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<TodoDto> CreateTodo(CreateTodoDto createTodoDto)
    {
      var todo = new Models.Todo
      {
        Title = createTodoDto.Title,
        IsCompleted = createTodoDto.IsCompleted,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
      };

      _context.Todos.Add(todo);
      await _context.SaveChangesAsync();

      return new TodoDto
      {
        Id = todo.Id,
        Title = todo.Title,
        IsCompleted = todo.IsCompleted,
        CreatedAt = todo.CreatedAt,
        UpdatedAt = todo.UpdatedAt
      };
    }

    public async Task<List<TodoDto>> GetAllTodos()
    {
      var todos = await _context.Todos.ToListAsync();
      
      return todos.Select(t => new TodoDto
      {
        Id = t.Id,
        Title = t.Title,
        IsCompleted = t.IsCompleted,
        CreatedAt = t.CreatedAt,
        UpdatedAt = t.UpdatedAt
      }).ToList();
    }

    public async Task<TodoDto> GetTodoById(int id)
    {
      var todo = await _context.Todos.FindAsync(id);
      
      if (todo == null)
      {
        return null!;
      }

      return new TodoDto
      {
        Id = todo.Id,
        Title = todo.Title,
        IsCompleted = todo.IsCompleted,
        CreatedAt = todo.CreatedAt,
        UpdatedAt = todo.UpdatedAt
      };
    }

    public async Task<TodoDto> UpdateTodo(int id, TodoDto todoDto)
    {
      var todo = await _context.Todos.FindAsync(id);
      
      if (todo == null)
      {
        return null!;
      }

      todo.Title = todoDto.Title;
      todo.IsCompleted = todoDto.IsCompleted;
      todo.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();

      todoDto.Id = todo.Id;
      todoDto.CreatedAt = todo.CreatedAt;
      todoDto.UpdatedAt = todo.UpdatedAt;
      return todoDto;
    }

    public async Task<TodoDto> DeleteTodo(int id)
    {
      var todo = await _context.Todos.FindAsync(id);
      
      if (todo == null)
      {
        return null!;
      }

      var todoDto = new TodoDto
      {
        Id = todo.Id,
        Title = todo.Title,
        IsCompleted = todo.IsCompleted,
        CreatedAt = todo.CreatedAt,
        UpdatedAt = todo.UpdatedAt
      };

      _context.Todos.Remove(todo);
      await _context.SaveChangesAsync();

      return todoDto;
    }
  }
}
