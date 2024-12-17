using ArticlesAppProject.Domain.Enums;

namespace ArticlesAppProject.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Roles Role { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
}
