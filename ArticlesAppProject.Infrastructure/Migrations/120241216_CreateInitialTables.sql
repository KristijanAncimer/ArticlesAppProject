CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    NumberOfArticles INT NOT NULL DEFAULT 0
);

CREATE TABLE Articles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CategoryId INT NOT NULL,
    PictureUrl NVARCHAR(2083) NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Articles_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);


CREATE TABLE Roles(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(50) NOT NULL
);
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    DateCreated DATETIME NOT NULL DEFAULT GETDATE(),
    Active BIT NOT NULL DEFAULT 1
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);

CREATE INDEX IX_Categories_Title ON Categories (Title);
CREATE INDEX IX_Articles_Title ON Articles (Title);


INSERT INTO Roles (Title)
VALUES ('Administrator'), ('User')

INSERT INTO Categories (Title)
VALUES ('Food'), ('Games'), ('Alcohol')
