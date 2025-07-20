USE BookManagementSystem;
GO

-- =============================================
-- [dbo].[GetAvailableBooks]
-- Returns all available books
-- =============================================
CREATE PROCEDURE [dbo].[GetAvailableBooks]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [BookID], [Title], [Author], [PublicationYear], [IsAvailable]
    FROM [dbo].[Books]
END
GO

-- =============================================
-- [dbo].[GetBookById]
-- Returns a single book by ID
-- =============================================
CREATE PROCEDURE [dbo].[GetBookById]
    @BookID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [BookID], [Title], [Author], [PublicationYear], [IsAvailable]
    FROM [dbo].[Books]
    WHERE [BookID] = @BookID;
END
GO

-- =============================================
-- [dbo].[AddBook]
-- Adds a new book record
-- =============================================
CREATE PROCEDURE [dbo].[AddBook]
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @PublicationYear INT,
    @IsAvailable BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Books] ([Title], [Author], [PublicationYear], [IsAvailable])
    VALUES (@Title, @Author, @PublicationYear, @IsAvailable);
END
GO

-- =============================================
-- [dbo].[UpdateBook]
-- Updates an existing book by ID
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBook]
    @BookID INT,
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @PublicationYear INT,
    @IsAvailable BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Books]
    SET [Title] = @Title,
        [Author] = @Author,
        [PublicationYear] = @PublicationYear,
        [IsAvailable] = @IsAvailable
    WHERE [BookID] = @BookID;
END
GO

-- =============================================
-- [dbo].[RemoveBook]
-- Deletes a book by ID
-- =============================================
CREATE PROCEDURE [dbo].[RemoveBook]
    @BookID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[Books]
    WHERE [BookID] = @BookID;
END
GO

-- =============================================
-- [dbo].[SearchBooks]
-- Searches books by keyword (title or author)
-- =============================================
CREATE PROCEDURE [dbo].[SearchBooks]
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [BookID], [Title], [Author], [PublicationYear], [IsAvailable]
    FROM [dbo].[Books]
    WHERE [Title] LIKE '%' + @Keyword + '%'
       OR [Author] LIKE '%' + @Keyword + '%';
END
GO
