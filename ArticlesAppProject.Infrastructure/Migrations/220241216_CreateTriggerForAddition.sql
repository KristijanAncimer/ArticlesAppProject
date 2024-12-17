CREATE TRIGGER trigger_UpdateNumerOfArticles_AfterInsert
ON Articles
AFTER INSERT
AS
BEGIN
    UPDATE Categories
    SET NumberOfArticles = NumberOfArticles + 1
    FROM Categories
    INNER JOIN Inserted i ON Categories.Id = i.CategoryId;
END;