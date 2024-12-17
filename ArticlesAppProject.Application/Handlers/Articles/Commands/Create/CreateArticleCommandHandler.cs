using Dapper;
using System.Data;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Create;

public class CreateArticleCommandHandler
{
    private readonly IDbConnection _dbConnection;
    public CreateArticleCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async void Handle(CreateArticleCommand command, CancellationToken cancellationToken)
    {
        var sql = @"
            INSERT INTO Articles (Title, Price, CategoryId, PictureUrl)
            VALUES (@Title, @Price, @CategoryId, @PictureUrl);";

        var parameterId = (int)command.Category;
        //Need to call get by title endpoint to determine if the same title exists

        var parameters = new
        {
            command.Title,
            command.Price,
            parameterId,
            command.PictureUrl
        };
        await _dbConnection.ExecuteAsync(sql, parameters);
    }
}
