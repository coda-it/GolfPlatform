CREATE TABLE dbo.UserModel
(
    Id INT IDENTITY PRIMARY KEY,
    Email NVARCHAR(50),
    Password NVARCHAR(50),
    Points INTEGER,
);  