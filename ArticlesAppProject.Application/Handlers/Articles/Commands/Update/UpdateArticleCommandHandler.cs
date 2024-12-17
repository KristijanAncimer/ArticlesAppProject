using ArticlesAppProject.Application.Handlers.Articles.Commands.Delete;
using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using ArticlesAppProject.Domain.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Update;

public class UpdateArticleCommandHandler
{
    private readonly IDbConnection _dbConnection;
    public UpdateArticleCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async void Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
    {
        const string getArticleSql = "SELECT Id, Title, Price, CategoryId, PictureUrl FROM Articles WHERE Id = @Id";
        var parameter = command.Id;
        var existingArticle = await _dbConnection.QuerySingleOrDefaultAsync<Domain.Models.Articles>(getArticleSql, parameter);
        //there needs to be some exception or warning here if no existing article to update is found

        //Need to call get by title endpoint to determine if the same title exists
        var parameters = new
        {
            Title = command.Title ?? existingArticle.Title,
            Price = command.Price ?? existingArticle.Price,
            PictureUrl = command.PictureUrl ?? existingArticle?.PictureUrl,
        };
        const string sql = @"
            UPDATE Articles
            SET 
                Title = @Title, 
                Price = @Price, 
                CategoryId = @CategoryId, 
                PictureUrl = @PictureUrl
            WHERE Id = @Id";

        await _dbConnection.ExecuteAsync(sql, parameters);
    }
}
