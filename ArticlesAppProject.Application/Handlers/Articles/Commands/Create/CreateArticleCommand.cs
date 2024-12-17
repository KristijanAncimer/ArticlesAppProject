using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Create;

public class CreateArticleCommand
{
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    public Categories Category { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
}
