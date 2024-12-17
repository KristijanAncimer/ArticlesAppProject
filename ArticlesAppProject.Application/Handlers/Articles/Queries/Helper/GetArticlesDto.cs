using ArticlesAppProject.Domain.Enums;

namespace ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;

public class GetArticlesDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public Categories Categories { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
}
