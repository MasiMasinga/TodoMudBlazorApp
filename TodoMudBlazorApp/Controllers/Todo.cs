using Microsoft.AspNetCore.Mvc;
using Todo.Interface;
using Todo.DTOs;

namespace Todo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TodoController : ControllerBase
  {
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
      _todoService = todoService;
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> CreateTodo([FromBody] CreateTodoDto todo)
    {
      var createdTodo = await _todoService.CreateTodo(todo);

      if (createdTodo == null!)
      {
        return BadRequest();
      }
      
      return CreatedAtAction(nameof(GetTodoById), new { id = createdTodo.Id }, createdTodo);
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoDto>>> GetAllTodos()
    {
      var todos = await _todoService.GetAllTodos();
      
      return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoDto>> GetTodoById(int id)
    {
      var todo = await _todoService.GetTodoById(id);
      
      if (todo == null!)
      {
        return NotFound();
      }
      
      return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TodoDto>> UpdateTodo(int id, [FromBody] TodoDto todo)
    {
      var updatedTodo = await _todoService.UpdateTodo(id, todo);
      
      if (updatedTodo == null!)
      {
        return NotFound();
      }

      return Ok(updatedTodo);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TodoDto>> DeleteTodo(int id)
    {
      var deletedTodo = await _todoService.DeleteTodo(id);
      
      if (deletedTodo == null!)
      {
        return NotFound();
      }
      
      return Ok(deletedTodo);
    }
  }
}