USE TestDB;

DECLARE @AuthorId UNIQUEIDENTIFIER = 'C5C2F8A4-447C-4688-ADFB-21EA7A1F8038';

SELECT A.FirstName AS AuthorName, B.Name AS BookName, G.Name as GenreName
FROM Authors AS A
JOIN Books AS B ON B.AuthorId = A.Id
JOIN Book_genre_links AS BGL ON B.Id = BGL.BookId
JOIN Genres AS G ON BGL.GenreId = G.Id
WHERE A.Id = @AuthorId