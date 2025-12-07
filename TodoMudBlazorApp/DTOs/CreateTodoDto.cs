using System.ComponentModel.DataAnnotations;

namespace Todo.DTOs
{
  public class CreateTodoDto
  {
    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;
  }
}

