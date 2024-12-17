using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using Dapper;
using MediatR;
using System.Data;
using System.Text;

namespace ArticlesAppProject.Application.Handlers.Articles.Queries.GetAll;

public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<GetArticlesDto>>
{
    private readonly IDbConnection _dbConnection;

    public GetArticlesQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<GetArticlesDto>> Handle(GetArticlesQuery query, CancellationToken cancellationToken)
    {
        var sql = new StringBuilder();
        sql.Append("SELECT Id, Title, Price, CategoryId, PictureUrl, DateCreated FROM Articles");

        var parameters = new DynamicParameters();

        if (query.FilterBy != Categories.All)
        {
            sql.Append(" WHERE CategoryId = @CategoryId");
            parameters.Add("@CategoryId", (int)query.FilterBy);
        }

        switch (query.SortBy)
        {
            case SortBy.Price:
                sql.Append(" ORDER BY Price ASC");
                break;
            case SortBy.Title:
                sql.Append(" ORDER BY Title ASC");
                break;
            case SortBy.Category:
                sql.Append(" ORDER BY CategoryId ASC");
                break;
            default:
                sql.Append(" ORDER BY DateCreated DESC");
                break;
        }

        sql.Append(" OFFSET @PageSize*(@PageNumber-1) ROWS FETCH NEXT @PageSize ROWS ONLY");
        parameters.Add("@PageSize", query.PageSize);
        parameters.Add("@PageNumber", query.PageNumber);

        var articles = await _dbConnection.QueryAsync<Domain.Models.Articles>(sql.ToString(), parameters);
        return articles.Select(article => new GetArticlesDto
        {
            Id = article.Id,
            Title = article.Title,
            Price = article.Price,
            Categories = (Categories)article.CategoryId,
            PictureUrl = article.PictureUrl,
            DateCreated = article.DateCreated
        });
    }
}
