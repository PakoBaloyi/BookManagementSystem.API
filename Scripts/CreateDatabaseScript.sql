CREATE DATABASE BookManagementSystem;
GO


USE BookManagementSystem;
GO


-- Create Books table
CREATE TABLE [dbo].[Books]
(
    [BookID] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] NVARCHAR(255) NOT NULL,
    [Author] NVARCHAR(255) NOT NULL,
    [PublicationYear] INT NOT NULL,
    [IsAvailable] BIT NOT NULL
);
GO


USE BookManagementSystem;
GO

-- Insert sample book records
INSERT INTO [dbo].[Books] ([Title], [Author], [PublicationYear], [IsAvailable]) VALUES
('Pako Vs Blazor', 'Pako Dev', 2025, 1),
('Clean Code', 'Robert C. Martin', 2008, 1),
('Design Patterns', 'Erich Gamma', 1994, 1),
('Domain-Driven Design', 'Eric Evans', 2003, 1),
('You Don''t Know JS', 'Kyle Simpson', 2015, 0),
('Refactoring', 'Martin Fowler', 2019, 1),
('The Pragmatic Programmer', 'Andrew Hunt', 1999, 1),
('The Clean Coder', 'Robert C. Martin', 2011, 1),
('Effective Java', 'Joshua Bloch', 2018, 0),
('Head First Design Patterns', 'Eric Freeman', 2020, 1);
GO


