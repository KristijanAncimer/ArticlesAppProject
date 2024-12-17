using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using MediatR;

namespace ArticlesAppProject.Application.Handlers.Articles.Queries.GetAll;

public class GetArticlesQuery : IRequest<IEnumerable<GetArticlesDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public SortBy SortBy { get; set; }
    public Categories FilterBy { get; set; }
    private GetArticlesQuery(int pageSize, int pageNumber, SortBy sortby, Categories filterBy)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
        SortBy = sortby;
        FilterBy = filterBy;
    }
    public static GetArticlesQuery Create(int pageSize, int pageNumber, SortBy sortby, Categories filterBy) =>
        new(pageSize, pageNumber, sortby, filterBy);

}
