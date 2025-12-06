using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TodoController : ControllerBase
  {
    private readonly AppDbContext _context;
  }
}