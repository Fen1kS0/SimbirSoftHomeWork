using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Entities;
using Library.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IQueryable<Book> query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Readers);
            
            return await query.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            IQueryable<Book> query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genres)
                .Include(b => b.Readers);
            
            return await query.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task UpdateBook(Book book)
        {
            await Task.Run(() =>
            {
                book.LastUpdateRecordDate = DateTimeOffset.Now;
                book.Version++;
                
                _context.Entry(book).State = EntityState.Modified;
            });
        }

        public async Task DeleteBook(Book book)
        {
            await Task.Run(() =>
            {
                _context.Books.Remove(book);
            });
        }
        
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}