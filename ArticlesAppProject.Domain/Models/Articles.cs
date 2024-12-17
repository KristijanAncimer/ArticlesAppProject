using ArticlesAppProject.Domain.Enums;

namespace ArticlesAppProject.Domain.Models;

public class Articles
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
}
