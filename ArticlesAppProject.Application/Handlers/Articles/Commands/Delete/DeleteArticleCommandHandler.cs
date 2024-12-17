using ArticlesAppProject.Application.Handlers.Articles.Commands.Create;
using Dapper;
using System.Data;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Delete;

public class DeleteArticleCommandHandler
{
    private readonly IDbConnection _dbConnection;
    public DeleteArticleCommandHandler(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async void Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
    {
        const string sql = "DELETE FROM Articles WHERE Id = @Id";

        var parameters = new { Id =  command.Id };

        await _dbConnection.ExecuteAsync(sql, parameters);
    }
}
