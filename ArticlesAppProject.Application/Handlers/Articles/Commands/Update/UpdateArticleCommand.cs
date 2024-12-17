using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using ArticlesAppProject.Domain.Models;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Update;

public class UpdateArticleCommand
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public double? Price { get; set; }
    public string? PictureUrl { get; set; }
}
