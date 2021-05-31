CREATE DATABASE TestDB;
GO
USE TestDB;
CREATE TABLE Authors
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    MiddleName NVARCHAR(MAX)
)

CREATE TABLE Books
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Name NVARCHAR(MAX) NOT NULL,
	AuthorId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors (Id) ON DELETE CASCADE
)

CREATE TABLE Genres
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Name NVARCHAR(MAX) NOT NULL
)

CREATE TABLE People
(
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    MiddleName NVARCHAR(MAX),
	BirthDate DATETIME NOT NUll
)

CREATE TABLE Book_genre_links
(
	BookId UNIQUEIDENTIFIER NOT NULL,
	GenreId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Books (Id) ON DELETE CASCADE,
	FOREIGN KEY (GenreId) REFERENCES Genres (Id) ON DELETE CASCADE,
	PRIMARY KEY (BookId, GenreId)
)

CREATE TABLE Library_card
(
	BookId UNIQUEIDENTIFIER NOT NULL,
	PersonId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Books (Id) ON DELETE CASCADE,
	FOREIGN KEY (PersonId) REFERENCES People (Id) ON DELETE CASCADE,
	PRIMARY KEY (BookId, PersonId)
)