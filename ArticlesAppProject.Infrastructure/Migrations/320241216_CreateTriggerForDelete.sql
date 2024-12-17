CREATE TRIGGER trigger_UpdateNumerOfArticles_AfterDelete
ON Articles
AFTER DELETE
AS
BEGIN
    UPDATE Categories
    SET NumberOfArticles = NumberOfArticles - 1
    FROM Categories
    INNER JOIN Deleted d ON Categories.Id = d.CategoryId;
END;