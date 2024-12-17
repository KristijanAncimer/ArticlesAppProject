using Dapper;
using MediatR;
using System.Data;

namespace ArticlesAppProject.Application.Handlers.Articles.Queries.GetById;

public class GetArticlesByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, bool>
{
    private readonly IDbConnection _dbConnection;

    public GetArticlesByIdQueryHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<bool> Handle(GetArticleByIdQuery query, CancellationToken cancellationToken)
    {
        //    var sql = new StringBuilder();
        //    sql.Append("SELECT Id, Title, Price, CategoryId, PictureUrl, DateCreated FROM Articles");

        //    var parameters = new DynamicParameters();
        //    sql.Append(" WHERE Id = @Id");
        //    parameters.Add("@Id", query.Id);

        //    var articles = await _dbConnection.QueryAsync<Domain.Models.Articles>(sql.ToString(), parameters);

        //    if(articles == null) return new GetArticlesDto();

        //    return new GetArticlesDto
        //    {
        //        Id = articles.First().Id,
        //        Title = articles.First().Title,
        //        Price = articles.First().Price,
        //        Categories = (Categories)articles.First().CategoryId,
        //        PictureUrl = articles.First().PictureUrl,
        //        DateCreated = articles.First().DateCreated
        //    };
        const string sql = "SELECT 1 FROM Articles WHERE Title = @Title LIMIT 1";

        var result = await _dbConnection.QuerySingleOrDefaultAsync<int?>(sql, new { query.Title });

        return result.HasValue;
    }
}
