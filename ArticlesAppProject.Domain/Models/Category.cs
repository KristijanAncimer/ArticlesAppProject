using System.ComponentModel.DataAnnotations;

namespace ArticlesAppProject.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public int NumberOfArticles { get; set; } = 0;
}
