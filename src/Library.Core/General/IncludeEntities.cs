using System.Linq;
using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.Core.General
{
    public static class IncludeEntities
    {
        public static IIncludableQueryable<Author, object> IncludeAllForAuthor(IQueryable<Author> query)
        {
            return query
                .Include(a => a.Books)
                .ThenInclude(b => b.Readers)
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres);
        }

        public static IIncludableQueryable<Book, object> IncludeAllForBook(IQueryable<Book> query)
        {
            return query
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Readers);
        }
        
        public static IIncludableQueryable<Genre, object> IncludeAllForGenre(IQueryable<Genre> query)
        {
            return query
                .Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Readers);
        }
        
        public static IIncludableQueryable<Person, object> IncludeAllForPerson(IQueryable<Person> query)
        {
            return query
                .Include(g => g.Books)
                .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                .ThenInclude(b => b.Genres);
        }
    }
}