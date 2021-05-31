USE TestDB;

DECLARE @PersonId UNIQUEIDENTIFIER = 'EA526165-5BA7-48B0-879A-99F044E95EAC';

SELECT P.FirstName AS PersonName, B.Name AS BookName, A.FirstName AS AuthorName, G.Name as GenreName
FROM People AS P
JOIN Library_card AS LC ON P.Id = LC.PersonId
JOIN Books AS B ON LC.BookId = B.Id
JOIN Authors AS A ON B.AuthorId = A.Id
JOIN Book_genre_links AS BGL ON B.Id = BGL.BookId
JOIN Genres AS G ON BGL.GenreId = G.Id
WHERE P.Id = @PersonId