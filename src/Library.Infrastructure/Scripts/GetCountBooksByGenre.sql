USE TestDB;

SELECT G.Name as GenreName, COUNT(*) as CountBook
FROM Genres as G
JOIN Book_genre_links AS BGL ON BGL.GenreId = G.Id
JOIN Books AS B ON B.Id = BGL.BookId
GROUP BY G.Name