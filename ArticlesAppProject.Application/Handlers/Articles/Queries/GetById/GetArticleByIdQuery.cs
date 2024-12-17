using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using MediatR;

namespace ArticlesAppProject.Application.Handlers.Articles.Queries.GetById;

public class GetArticleByIdQuery : IRequest<bool>
{
    public string Title { get; set; }
    private GetArticleByIdQuery(string title)
    {
        Title = title;
    }
    public static GetArticleByIdQuery Create(string title) => new (title);
}
